<script setup>
import { defineProps } from 'vue'

defineProps({
  Delete: Function,
  Cancel: Function,
})
</script>
<template>
  <div class="fixed z-10 bg-slate-100 bg-opacity-50 w-full h-full">
    <div
      class="flex flex-col gap-4 fixed top-1/2 left-1/2 z-20 -translate-x-1/2 -translate-y-1/2 font-mono text-md bg-slate-200 p-6 rounded-md shadow-md"
    >
      <p class="text-center">Удалить товар из избранного?</p>
      <div class="flex justify-around">
        <button
          @click="Delete"
          class="bg-slate-300 p-2 rounded-md leading-3 transition-all hover:bg-slate-400"
        >
          Да
        </button>
        <button
          @click="Cancel"
          class="bg-slate-300 p-2 rounded-md leading-3 transition-all hover:bg-slate-400"
        >
          Отмена
        </button>
      </div>
    </div>
  </div>
</template>

<style></style>
