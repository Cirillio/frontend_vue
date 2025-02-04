<!-- eslint-disable vue/multi-word-component-names -->
<script setup>
import CardList from '../components/CardList.vue'
import { onMounted, reactive, watch, inject } from 'vue'

import axios from 'axios'

const { items, fetchData } = inject('items')

const fetchDataUsingFilters = async () => {
  const params = {
    sortBy: filters.sortBy,
  }
  if (filters.search) {
    params.name = `*${filters.search}*`
  }
  fetchData(params)
}

const filters = reactive({
  sortBy: 'title',
  search: '',
})

const onChangeSelect = (event) => {
  filters.sortBy = event.target.value
}

const onSearchChange = (event) => {
  filters.search = event.target.value
}

watch(filters, () => fetchDataUsingFilters())
</script>

<template>
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
        class="border rounded-md py-2 pl-11 pr-4 outline-none focus:border-gray-400"
        type="text"
        placeholder="Поиск..."
      />
    </div>
  </div>
  <CardList :products="items" />
</template>
