<script setup>
import Card from './Card.vue'

defineProps({
  products: Array,
})

const ClickAdd = function (text) {
  alert(text)
}
</script>

<template>
  <div class="grid gap-5 sm:grid-cols-2 lg:grid-cols-3 xl:grid-cols-4">
    <Card
      v-for="product in products"
      :key="product.id"
      :image-url="product.imgUrl"
      :product-name="product.name"
      :product-price="product.price"
      :is-favorite="true"
      :is-added="false"
      @click-add="ClickAdd('Добавилось в корзину!')"
    />
  </div>
</template>
<style></style>
