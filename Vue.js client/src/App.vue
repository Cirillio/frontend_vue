<script setup>
import CardItem from './components/CardItem.vue'
import CartItem from './components/CartItem.vue'

import axios from 'axios'
import { ref, onMounted, watch } from 'vue'

const apiProducts = 'http://localhost:5154/api/products'
const apiCart = 'http://localhost:5154/api/cart'
const products = ref([])
const cartList = ref([])

const fetchData = async (url) => {
  try {
    const response = await axios.get(url)

    if (response.data === null) {
      throw new Error('No data found')
    }

    products.value = response.data
  } catch (error) {
    console.error(error.message)
  }
}

////////

function updateCart(newItem) {
  // Добавляем новый товар в корзину
  cartList.value.push(newItem)
  console.log('Updated cart list:', cartList.value)
}

/////
// Функция для получения данных с сервера
const watchCartList = async () => {
  try {
    const response = await axios.get(apiCart)
    cartList.value = response.data // Обновляем данные
  } catch (error) {
    console.error('Error fetching data:', error)
  }
}

watchCartList()

/////
onMounted(() => fetchData(apiProducts))
</script>

<template>
  <div class="bg-slate-200 w-4/5 h-screen m-auto">
    <div class="flex flex-wrap justify-center w-full">
      <h1 class="w-full text-center my-10 text-5xl font-Source text-white font-bold drop-shadow-md">
        REST API TEST
      </h1>
      <div class="w-3/6 min-h-80 flex flex-col rounded-lg mr-10 bg-slate-100 shadow-md p-2">
        <h2 class="text-3xl my-2 font-Source font-bold self-center">All Products</h2>

        <div class="grid grid-cols-4 gap-2">
          <CardItem
            v-for="product in products"
            :key="product.id"
            :title="product.title"
            :price="product.price"
            :img="product.img"
            @itemAdded="updateCart"
          />
        </div>
      </div>

      <div class="w-2/6 max-h-fit flex flex-col rounded-lg bg-slate-100 shadow-md p-2 font-Source">
        <h2 class="text-3xl my-2 font-bold self-center">Cart list</h2>
        <div class="flex flex-col gap-2">
          <CartItem
            v-for="cartItem in cartList"
            :key="cartItem.id"
            :title="cartItem.title"
            :price="cartItem.price"
            :img="cartItem.img"
            :amount="cartItem.amount"
          />
        </div>
      </div>
    </div>
  </div>
</template>

<style scoped></style>
