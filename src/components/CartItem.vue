<script setup>
defineProps({
  id: Number,
  name: String,
  price: Number,
  imgUrl: String,
})
</script>

<template>
  <div class="flex items-center border border-slate-200 p-4 rounded-xl">
    <img class="w-16 h-16" :src="imgUrl" alt="sneaker1" />
    <div class="flex flex-col">
      <p>{{ name }}</p>
      <div class="flex justify-between mt-2">
        <b>{{ price }}р.</b>
        <img
          class="cursor-pointer opacity-40 hover:opacity-100 transition-all"
          src="/public/close.svg"
          alt="remove"
        />
      </div>
    </div>
  </div>
</template>

<style></style>
