<script setup>
defineProps({
  title: String,
  price: Number,
  img: String,
  amount: {
    type: Number,
    default: 1,
  },
})
</script>
<template>
  <div class="flex w-full h-24 items-center p-2 bg-white gap-5 rounded-md">
    <div
      class="h-full p-2 border border-slate-200 rounded-md items-center justify-center flex aspect-square"
    >
      <img class="h-full" :src="img" alt="cartitem" />
    </div>
    <div class="w-full">
      <p class="font-bold">{{ title }}</p>
      <p>Price: {{ price * amount }}</p>
    </div>
    <div class="addAmount flex w-fit cursor-pointer bg-black">
      <button @click="removeAmount" class="w-2 bg-slate-100"><</button>
      <input
        @input="checkInput"
        type="text"
        class="w-6 text-center bg-slate-200 text-xs focus:outline-none"
      />
      <button @click="addAmount" class="w-2 bg-slate-100">></button>
    </div>
    <button class="h-3/5 contrast-100 transition-all hover:contrast-75">
      <img class="h-full" src="/icons/close.svg" alt="remove" />
    </button>
  </div>
</template>

<style></style>
