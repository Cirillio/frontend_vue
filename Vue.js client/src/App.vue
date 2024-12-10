<script setup>
import CardItem from './components/CardItem.vue'
import CartItem from './components/CartItem.vue'

import axios from 'axios'
import { ref, onMounted, watch } from 'vue'

const apiProducts = 'http://localhost:5154/api/products'
const apiCart = 'http://localhost:5154/api/cart'
const products = ref([])
const cartList = ref([])

const LoadProducts = async (url) => {
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

// Функция для получения данных с сервера
const LoadCart = async () => {
  try {
    const response = await axios.get(apiCart)
    if (response.data === null) {
      cartList.value = []
      throw new Error('No data found')
    }
    cartList.value = response.data // Обновляем данные
  } catch (error) {
    console.error('Error fetching data:', error)
  }
}

const SearchProducts = async (name, query) => {
  try {
    if (name === null || query === null) {
      throw new Error('query Error')
    }
    const response = await axios.get(apiProducts + '?' + name + '=' + query)

    if (response.status === 200) {
      products.value = response.data
    } else {
      throw new Error('No data found')
    }
  } catch (error) {
    console.log('Error finding data: ' + error)
  }
}

const AddProduct = async (api, product) => {
  try {
    const response = await axios.post(api, product)
    if (response.status == 200) {
      LoadProducts(apiProducts)
    } else {
      throw new Error('something went wrong...')
    }
  } catch (error) {
    console.log(error)
  }
}

const startLoad = async () => {
  await LoadCart()
  await LoadProducts(apiProducts)
}

/////
onMounted(async () => await startLoad())
///

document.addEventListener('DOMContentLoaded', () => {
  const search = document.getElementById('search')
  const searchRadio = Array.from(search.querySelectorAll('input[type="radio"]'))
  const searchInput = search.querySelector("input[name='search']")
  const searchBtn = search.querySelectorAll('button')[0]
  const clearBtn = search.querySelectorAll('button')[1]
  let searchName = ''
  let searchQuery = ''

  searchRadio.forEach((radio) => {
    radio.addEventListener('change', () => {
      searchRadio.forEach((elem) => {
        elem.checked = false
      })
      radio.checked = true
      searchName = radio.name
    })
  })

  searchInput.addEventListener('change', () => {
    searchQuery = searchInput.value
  })

  searchBtn.addEventListener('click', async () => await SearchProducts(searchName, searchQuery))

  clearBtn.addEventListener('click', () => {
    searchInput.value = ''
    searchQuery = ''
    LoadProducts(apiProducts)
  })

  const addProdBtn = document.getElementById('addProdBtn')
  const newProd = document.getElementById('newProduct')
  const newProdBg = newProd.parentElement
  const inputNewImg = newProd.querySelector("input[name='file']")
  const inputNewTitle = newProd.querySelector('input[name="title"]')
  const inputNewPrice = newProd.querySelector('input[name="price"]')
  const addNewProduct = newProd.querySelector('button')

  const newProdImg = newProd.querySelector('img')

  const openAddProd = function () {
    newProdBg.classList.remove('hidden')
  }

  const closeAddProd = function (e) {
    if (e.classList.contains('close')) {
      newProdBg.classList.add('hidden')
    }
  }

  addProdBtn.addEventListener('click', () => openAddProd())

  newProdBg.addEventListener('click', (e) => closeAddProd(e.target))

  inputNewImg.addEventListener('change', () => {
    console.log(newProdBg)
    newProdImg.src = '/products/' + inputNewImg.files[0].name
    newProdImg.classList.remove('hidden')
  })

  addNewProduct.addEventListener('click', () => {
    try {
      const newTitle = inputNewTitle.value.trim()
      const newPrice = inputNewPrice.value.trim()
      const newImg = inputNewImg.files.length > 0 ? inputNewImg.files[0].name.trim() : ''

      if (!newTitle) {
        throw new Error('wrong title.')
      }

      if (newTitle.length > 100) {
        throw new Error('title length is too long.')
      }

      if (!newPrice || isNaN(newPrice) || newPrice <= 0) {
        throw new Error('wrong price.')
      }

      if (!newImg) {
        throw new Error('wrong img.')
      }

      let newProduct = {
        title: newTitle,
        price: newPrice,
        img: '/products/' + newImg,
      }
      AddProduct(apiProducts, newProduct)
      closeAddProd(newProdBg)
      inputNewTitle.value = null
      inputNewPrice.value = null
      inputNewImg.files = null
      console.log(newProduct)
      addNewProduct.setAttribute('disabled', true)
      setTimeout(() => {
        addNewProduct.removeAttribute('disabled')
      }, 5000)
    } catch (error) {
      console.log('Error adding product: ' + error)
    }
  })
})
</script>

<template>
  <div
    class="close hidden fixed z-20 w-full h-full bg-black/50 flex flex-col items-center justify-center"
  >
    <div id="newProduct" class="bg-white p-5 items-center rounded-md gap-5 flex font-Source">
      <label
        class="relative overflow-hidden cursor-pointer flex items-center justify-center h-60 w-60 border text-slate-200 border-slate-200 transition-all hover:border-slate-400 hover:text-slate-400 active:opacity-50"
      >
        <input
          type="file"
          name="file"
          accept="image/*"
          class="absolute -z-1 block opacity-0 w-0 h-0"
        />
        <span class="relative inline-block outline-none text-center p-2">Выберите файл</span>
        <img
          class="absolute top-0 left-0 h-full w-full object-cover hidden"
          src=""
          alt="productimage"
        />
      </label>
      <div class="flex flex-col gap-2 items-end justify-center">
        <h2 class="font-bold text-2xl text-center w-full">Add product</h2>
        <p>title:</p>
        <input
          autocomplete="off"
          class="focus:outline-none border border-slate-200 rounded-md px-2 transition focus:border-slate-600"
          type="text"
          name="title"
        />
        <p>price:</p>
        <input
          autocomplete="off"
          class="focus:outline-none border border-slate-200 rounded-md px-2 transition focus:border-slate-600"
          type="text"
          name="price"
        />
        <button
          class="bg-slate-200 w-2/3 rounded-md mt-5 h-10 transition-all hover:bg-slate-400 active:-translate-y-1 disabled:opacity-30"
        >
          Добавить
        </button>
      </div>
    </div>
    <p class="select-none">Click on empty space to close</p>
  </div>

  <div class="bg-slate-200 w-4/5 min-h-screen m-auto">
    <div class="flex flex-wrap justify-center w-full">
      <h1 class="w-full text-center my-10 text-5xl font-Source text-white font-bold drop-shadow-md">
        REST API TEST
      </h1>
      <div class="w-3/6 min-h-80 flex flex-col rounded-lg mr-10 bg-slate-100 shadow-md p-2">
        <h2 class="text-3xl my-2 font-Source font-bold self-center">All Products</h2>
        <div id="search" class="flex flex-wrap gap-2 w-full my-5 px-10 items-center">
          <p>Найти по:</p>
          <label for="id">
            <input name="id" type="radio" class="cursor-pointer" />
            id
          </label>
          <label for="title">
            <input name="title" type="radio" class="cursor-pointer" />
            title
          </label>
          <label for="price">
            <input name="price" type="radio" class="cursor-pointer" />
            price
          </label>
          <input
            autocomplete="off"
            class="p-1 px-2 rounded-md text-md focus:outline-none"
            type="text"
            name="search"
          />
          <button
            class="bg-slate-200 text-md p-1 px-2 rounded-md shadow-md transition-all scale-100 active:scale-90"
          >
            Искать
          </button>
          <button
            class="bg-slate-200 text-md p-1 px-2 rounded-md shadow-md transition-all scale-100 active:scale-90"
          >
            Очистить
          </button>
        </div>

        <div class="grid grid-cols-4 gap-2">
          <CardItem
            v-for="product in products"
            :key="product.id"
            :title="product.title"
            :price="product.price"
            :img="product.img"
            :onUpdateCart="LoadCart"
          />
          <button
            id="addProdBtn"
            class="bg-transparent border-4 text-slate-500 text-center justify-center border-white font-Source w-auto max-h-48 items-center flex flex-col gap-4 relative rounded-md p-6 transition-all hover:shadow-md hover:border hover:border-slate-500"
          >
            <p class="font-bold text-3xl">+</p>
            <p>Добавить товар</p>
          </button>
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
