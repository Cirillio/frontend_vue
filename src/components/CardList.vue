<script setup>
import Card from './Card.vue'

defineProps({
  products: Array,
})

const emit = defineEmits(['OnClickFavorite', 'OnClickCart'])
</script>

<template>
  <div v-auto-animate class="grid gap-5 sm:grid-cols-2 lg:grid-cols-3 xl:grid-cols-4">
    <Card
      v-for="product in products"
      :key="product.id"
      :id="product.id"
      :image-url="product.imgUrl"
      :product-name="product.name"
      :product-price="product.price"
      :is-favorite="product.isFavorite"
      :is-added="product.isAdded"
      :onClickFavorite="() => emit('OnClickFavorite', product)"
      :onClickAdd="() => emit('OnClickCart', product)"
    />
  </div>
</template>
<style></style>
