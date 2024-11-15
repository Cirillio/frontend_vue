<script setup>
import Header from './components/Header.vue'
import CardList from './components/CardList.vue'
import Drawer from './components/Drawer.vue'

import axios from 'axios'
import { onMounted, ref } from 'vue'

const itemsUrl = 'https://e8451dbd6147c45d.mokky.dev/products'

const items = ref([])

async function fetchData(url) {
  try {
    return await axios.get(url)
  } catch (error) {
    throw new Error(error.message)
  }
}

async function updateProducts() {
  try {
    const response = await fetchData(itemsUrl)
    items.value = response.data
    console.log(items.value)
  } catch (e) {
    console.error(e.message)
  }
}

onMounted(async () => {
  try {
    const response = await fetchData(itemsUrl)
    items.value = response.data
    console.log(items.value)
  } catch (e) {
    console.error(e.message)
  }
})
</script>

<template>
  <!-- <Drawer /> -->
  <button @click="updateProducts" class="absolute left-10 top-5 p-5 bg-lime-200 rounded-xl">
    Загрузить данные
  </button>
  <div class="w-4/5 m-auto bg-white h-full rounded-xl shadow-xl mt-10">
    <Header />

    <div class="p-10">
      <div class="flex justify-between items-center mb-10">
        <h2 class="text-3xl font-bold mb-5">Все кроссовки</h2>
        <div class="flex gap-4">
          <select class="py-2 px-3 border rounded-md outline-none cursor-pointer">
            <option class="cursor-pointer">По названию</option>
            <option class="cursor-pointer">По цене (дороже)</option>
            <option class="cursor-pointer">По цене (дешевле)</option>
          </select>
        </div>
        <div class="relative">
          <img class="absolute top-3 left-3" src="/public/search.svg" alt="search" />
          <input
            class="border rounded-md py-2 pl-11 pr-4 outline-none focud:border-gray-400"
            type="text"
            placeholder="Поиск..."
          />
        </div>
      </div>
      <CardList :products="items" />
    </div>
  </div>
</template>

<style></style>
