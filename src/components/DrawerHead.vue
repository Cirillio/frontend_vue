<template>
  <div class="w-full">
    <div @click="closeDrawer" class="flex w-fit items-baseline gap-5 cursor-pointer group">
      <svg
        class="rotate-180 opacity-30 group-hover:opacity-100 group-hover:-translate-x-1 transition-all"
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
      <h2 class="text-2xl font-bold select-none">Корзина</h2>
    </div>
  </div>
</template>

<script setup>
import { inject } from 'vue'

const { closeDrawer } = inject('cart')
</script>
