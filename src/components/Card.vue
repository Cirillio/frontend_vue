<script setup>
defineProps({
  imageUrl: String,
  productName: String,
  productPrice: Number,
  isFavorite: Boolean,
  isAdded: Boolean,
  onClickAdd: Function,
  onClickFavorite: Function,
})
</script>

<template>
  <div
    class="relative w-fit bg-white border border-slate-100 rounded-3xl p-8 cursor-pointer hover:-translate-y-2 hover:shadow-lg transition-all"
  >
    <img
      @click="onClickFavorite"
      class="absolute top-5 left-5"
      :src="isFavorite ? '/like1.svg' : 'like2.svg'"
      alt="favorite"
    />
    <img :src="imageUrl" alt="sneaker1" />
    <p class="mt-5">{{ productName }}</p>
    <div class="flex justify-between mt-5 flex-wrap">
      <div class="flex flex-col">
        <span class="text-slate-400">Цена</span>
        <b>{{ productPrice }}</b>
      </div>
      <img @click="onClickAdd" :src="isAdded ? '/checked.svg' : '/plus.svg'" alt="added" />
    </div>
  </div>
</template>
<style></style>
