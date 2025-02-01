<script setup>
import Header from './components/Header.vue'
import CardList from './components/CardList.vue'
import Drawer from './components/Drawer.vue'
import onClickFavorite from './components/onClickFavorite.vue'

import axios from 'axios'
import { onMounted, ref, h, render, reactive, watch, provide, computed } from 'vue'

const switchDrawer = ref(false)

const container = ref(null)

const itemsUrl = 'https://e8451dbd6147c45d.mokky.dev/products'

const items = ref([])

const cart = ref([])
const cartInitialized = ref(false)

const totalPrice = computed(() => cart.value.reduce((sum, item) => sum + item.price, 0))
const vatPrice = computed(() => Math.round((totalPrice.value * 5) / 100))

const filters = reactive({
  sortBy: 'title',
  search: '',
})

watch(filters, () => fetchData(itemsUrl))

const onChangeSelect = (event) => {
  filters.sortBy = event.target.value
}

const onSearchChange = (event) => {
  filters.search = event.target.value
}

const closeDrawer = () => {
  switchDrawer.value = false
}

const openDrawer = () => {
  switchDrawer.value = true
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
    productName: product.name,
    imgUrl: product.imgUrl,
    productPrice: product.price,
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
            await deleteFromFavorite(response.data.find((item) => item.product_id == product.id).id)
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
    await addToFavorite(favorite).catch((error) => {
      console.error(error)
    })
  }
}

const addToCart = async (product) => {
  const productInCart = {
    name: product.name,
    price: product.price,
    imgUrl: product.imgUrl,
    product_id: product.id,
  }
}

const deleteFromCart = async (product) => {}

const OnClickCart = async (product) => {
  product.isAdded = !product.isAdded
  product.isAdded ? await addToCart(product) : await deleteFromCart(product)
}

const fetchFavorites = async () => {
  await axios
    .get('https://e8451dbd6147c45d.mokky.dev/favorites')
    .then(({ data: favorites }) => {
      items.value = items.value.map((item) => {
        const favorite = favorites.find((favorite) => favorite.product_id === item.id)
        if (!favorite) {
          return item
        }
        return { ...item, isFavorite: true, favoriteId: favorite.id }
      })
    })
    .catch((error) => {
      console.error(error)
    })
}

const fetchCart = async () => {
  await axios
    .get('https://e8451dbd6147c45d.mokky.dev/cart')
    .then(({ data: cartList }) => {
      cart.value = cartList
    })
    .catch((error) => {
      console.error(error)
    })
}

const updateCart = async () => {
  await axios
    .put('https://e8451dbd6147c45d.mokky.dev/cart', cart.value)
    .then((response) => {
      const updatedCart = response.data
      console.log(updatedCart)
      // cart.value = updatedCart
    })
    .catch((error) => {
      console.error(error)
    })
}
const fetchData = async (url) => {
  const params = {
    sortBy: filters.sortBy,
  }
  if (filters.search) {
    params.name = `*${filters.search}*`
  }

  await axios
    .get(url, { params })
    .then((response) => {
      if (response.data !== null) {
        items.value = response.data
      }
      console.log(items.value)
    })
    .catch((error) => {
      console.error(error)
    })
}

onMounted(async () => {
  await fetchData(itemsUrl)
  await fetchFavorites()
  await fetchCart()
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

provide('cart', { closeDrawer, cart })
</script>

<template>
  <Drawer v-if="switchDrawer" :total-price="totalPrice" :vat-price="vatPrice" />
  <div ref="container"></div>
  <div class="w-4/5 m-auto bg-white h-full rounded-xl shadow-xl mt-10">
    <Header @open-drawer="openDrawer" :total-price="totalPrice" />

    <div class="p-10">
      <div class="flex wrap justify-between items-center mb-10">
        <h2 class="text-3xl font-bold mb-5">Все кроссовки</h2>
        <div class="flex gap-4">
          <select
            @change="onChangeSelect"
            class="py-2 px-3 border rounded-md outline-none cursor-pointer"
          >
            <option value="name" class="cursor-pointer">По названию</option>
            <option value="price" class="cursor-pointer">По цене (Возрастание)</option>
            <option value="-price" class="cursor-pointer">По цене (Убывание)</option>
          </select>
        </div>
        <div class="relative">
          <img class="absolute top-3 left-3" src="/public/search.svg" alt="search" />
          <input
            @input="onSearchChange"
            class="border rounded-md py-2 pl-11 pr-4 outline-none focud:border-gray-400"
            type="text"
            placeholder="Поиск..."
          />
        </div>
      </div>
      <CardList
        :products="items"
        @on-click-favorite="OnClickFavorite"
        @on-click-cart="OnClickCart"
      />
    </div>
  </div>
</template>

<style></style>
