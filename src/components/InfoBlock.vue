<template>
  <div class="flex flex-col flex-1 items-center justify-center text-center">
    <img :src="imgUrl" :alt="title" class="w-1/2" />
    <div class="my-5 flex items-center flex-col">
      <h2 class="text-3xl font-bold text-black text-opacity-80">{{ title }}</h2>
      <div class="w-[30%] h-1 bg-black rounded-lg bg-opacity-30 my-3"></div>
      <p class="text-md mx-10 text-slate-500">{{ info }}</p>
    </div>
    <button
      @click="closeDrawer"
      class="group bg-green-300 p-3 rounded-md flex items-baseline gap-2 shadow-lg hover:bg-green-400 transition-colors duration-300"
    >
      <svg
        class="rotate-180 opacity-50 group-hover:opacity-100 group-hover:-translate-x-[1px] transition-all"
        width="16"
        height="14"
        viewBox="0 0 16 14"
        fill="none"
        xmlns="http://www.w3.org/2000/svg"
      >
        <path
          d="M1 7H14.7143"
          stroke="black"
          stroke-width="2"
          stroke-linecap="round"
          stroke-linejoin="round"
        />
        <path
          d="M8.71436 1L14.7144 7L8.71436 13"
          stroke="black"
          stroke-width="2"
          stroke-linecap="round"
          stroke-linejoin="round"
        />
      </svg>
      <p
        class="text-lg opacity-70 group-hover:opacity-100 group-hover:-translate-x-[1px] transition-all"
      >
        Вернуться назад
      </p>
    </button>
  </div>
</template>

<script setup>
import { inject } from 'vue'
defineProps({
  title: String,
  info: String,
  imgUrl: String,
})

const { closeDrawer } = inject('cart')
</script>

<style></style>
