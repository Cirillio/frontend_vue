<script setup>
import onClickFavorite from './components/onClickFavorite.vue'
import Header from './components/Header.vue'
import Drawer from './components/Drawer.vue'

import axios from 'axios'

import { onMounted, ref, h, render, computed, watch, provide } from 'vue'

const container = ref(null)

const items = ref([])

const fetchData = async (params) => {
  await axios
    .get('https://e8451dbd6147c45d.mokky.dev/products', { params })
    .then((response) => {
      if (response.data !== null) {
        items.value = response.data
      }
    })
    .catch((error) => {
      console.error(error)
    })
}

provide('items', { items, fetchData })

//#region favorites
const favorites = ref([])

const fetchFavorites = async () => {
  await axios
    .get('https://e8451dbd6147c45d.mokky.dev/favorites?_relations=products')
    .then(({ data: _favorites }) => {
      _favorites.forEach((item) => {
        const { product } = item
        product.favoriteId = item.id
        product.isFavorite = true
        favorites.value.push(product)
      })

      console.log(favorites.value)
      items.value = items.value.map((item) => {
        item.isFavorite = false
        const favorite = favorites.value.find((favorite) => favorite.id === item.id)
        if (!favorite) {
          return item
        }
        item.isFavorite = true
        item.favoriteId = favorite.favoriteId
        return item
      })
    })
    .catch((error) => {
      console.error(error)
    })
}

const addToFavorite = async (product) => {
  await axios
    .post('https://e8451dbd6147c45d.mokky.dev/favorites', product)
    .then((response) => {
      console.log(response)
    })
    .catch((error) => {
      console.error('error adding favorite product' + error)
    })
}

const deleteFromFavorite = async (id) => {
  await axios
    .delete('https://e8451dbd6147c45d.mokky.dev/favorites/' + id)
    .then((response) => {
      console.log(response)
    })
    .catch((error) => {
      console.error(error)
    })
}

const OnClickFavorite = async (product) => {
  const favorite = {
    product_id: product.id,
  }
  if (product.isFavorite) {
    const vnode = h(onClickFavorite, {
      Delete: async () => {
        render(null, container.value)
        product.isFavorite = !product.isFavorite
        await axios
          .get('https://e8451dbd6147c45d.mokky.dev/favorites?product_id=' + product.id)
          .then(async (response) => {
            console.log(response)
            const deletingFavorite = response.data.find((item) => item.product_id == product.id)
            favorites.value.splice(favorites.value.indexOf(deletingFavorite), 1)
            await deleteFromFavorite(deletingFavorite.id)
          })
          .catch((error) => {
            console.error(error)
          })
      },
      Cancel: () => {
        render(null, container.value)
      },
    })
    render(vnode, container.value)
  } else {
    product.isFavorite = !product.isFavorite
    favorites.value.push(favorite)
    await addToFavorite(favorite).catch((error) => {
      console.error(error)
    })
  }
}

provide('favorites', { favorites, OnClickFavorite })

//#endregion favorites

const switchDrawer = ref(false)

const closeDrawer = () => {
  switchDrawer.value = false
}

const openDrawer = () => {
  switchDrawer.value = true
}

// #region Cart
const cart = ref([])
const cartInitialized = ref(false)

const fetchCart = async () => {
  await axios
    .get('https://e8451dbd6147c45d.mokky.dev/cart')
    .then(({ data: cartList }) => {
      cart.value = cartList

      items.value = items.value.map((item) => {
        const cartItem = cartList.find((cartItem) => cartItem.product_id === item.id)
        if (!cartItem) {
          return item
        }
        return { ...item, isAdded: true, cartItemId: cartItem.id }
      })
    })
    .catch((error) => {
      console.error(error)
    })
}

const updateCart = async () => {
  cart.value.forEach((item, index) => {
    item.id = index + 1
  })
  await axios
    .patch('https://e8451dbd6147c45d.mokky.dev/cart', cart.value)
    .then((response) => {
      console.log(response)
    })
    .catch((error) => {
      console.error(error)
    })
}

const totalPrice = computed(() => cart.value.reduce((sum, item) => sum + item.price, 0))
const vatPrice = computed(() => Math.round((totalPrice.value * 5) / 100))

const addToCart = async (product) => {
  const productInCart = {
    name: product.name,
    price: product.price,
    imgUrl: product.imgUrl,
    product_id: product.id,
  }
  cart.value.push(productInCart)
  product.isAdded = true
}

const deleteFromCart = async (id) => {
  cart.value.splice(cart.value.indexOf(cart.value.find((item) => item.product_id === id)), 1)
  items.value.find((item) => item.id === id).isAdded = false
}

const OnClickCart = async (product) => {
  product.isAdded ? await deleteFromCart(product.id) : await addToCart(product)
  console.table(product)
}

const makeOrder = async () => {
  console.log('makeOrder')
  await axios
    .post('https://e8451dbd6147c45d.mokky.dev/orders', {
      cart: cart.value,
      total_price: totalPrice.value,
      vat_price: vatPrice.value,
      order_created: Date(Date.now()),
    })
    .then((response) => {
      console.table(response)
      cart.value = []
      items.value.forEach((item) => (item.isAdded = false))
    })
    .catch((error) => {
      console.error(error)
    })
}

provide('cart', { cart, openDrawer, closeDrawer, OnClickCart, deleteFromCart, makeOrder })

watch(favorites, async () => {
  await fetchFavorites()
})

watch(
  cart,
  (newCart) => {
    if (cartInitialized.value) {
      updateCart()
    }
  },
  { deep: true },
)
// #endregion Cart
onMounted(async () => {
  await fetchData({
    sortBy: 'title',
  })
  await fetchCart()
  await fetchFavorites()
  cartInitialized.value = true
})
</script>

<template>
  <Drawer v-if="switchDrawer" :total-price="totalPrice" :vat-price="vatPrice" v-auto-animate />
  <div ref="container" class="fixed top-0 left-0 z-10"></div>
  <div class="w-4/5 m-auto bg-white h-full min-h-[90vh] rounded-xl shadow-xl mt-10">
    <Header :total-price="totalPrice" />

    <div class="p-10">
      <router-view></router-view>
    </div>
  </div>
</template>

<style></style>
