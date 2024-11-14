<script setup>
import Card from './Card.vue'
const ClickAdd = () => {
  alert('Добавилось!')
}

const ClickFav = function () {
  alert('Добавилось в закладки!')
}
</script>

<template>
  <div class="grid gap-5 sm:grid-cols-2 lg:grid-cols-3 xl:grid-cols-4">
    <Card
      image-url="/sneakers/sneakers-1.jpg"
      product-name="Nike Air Max 270"
      :product-price="12990"
      :is-favorite="true"
      :is-added="false"
      @click-add="ClickAdd"
      @click-favorite="ClickFav"
    />
    <Card
      image-url="/sneakers/sneakers-2.jpg"
      product-name="Nike Air Jordan"
      :product-price="14600"
      :is-favorite="false"
      :is-added="true"
    />
    <Card
      image-url="/sneakers/sneakers-3.jpg"
      product-name="Nike Air New Balance"
      :product-price="10990"
      :is-favorite="true"
      :is-added="false"
    />
    <Card
      image-url="/sneakers/sneakers-4.jpg"
      product-name="Adidas Yeezy Boost"
      :product-price="11950"
      :is-favorite="false"
      :is-added="true"
    />
    <Card
      image-url="/sneakers/sneakers-5.jpg"
      product-name="Puma Suede Classic"
      :product-price="8990"
      :is-favorite="true"
      :is-added="false"
    />
    <Card
      image-url="/sneakers/sneakers-6.jpg"
      product-name="Reebok Classic Leather"
      :product-price="7590"
      :is-favorite="false"
      :is-added="true"
    />
    <Card
      image-url="/sneakers/sneakers-7.jpg"
      product-name="Converse Chuck Taylor"
      :product-price="6500"
      :is-favorite="true"
      :is-added="false"
    />
    <Card
      image-url="/sneakers/sneakers-8.jpg"
      product-name="New Balance 574"
      :product-price="9990"
      :is-favorite="false"
      :is-added="true"
    />
  </div>
</template>
<style></style>
