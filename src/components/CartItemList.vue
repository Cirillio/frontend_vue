<script setup>
import CartItem from './CartItem.vue'

import { inject } from 'vue'

const { cart } = inject('cart')
const { deleteFromCart } = inject('cart')
</script>

<template>
  <div class="flex flex-col my-5 gap-2" v-auto-animate>
    <CartItem
      v-for="item in cart"
      :key="item.id"
      :id="item.id"
      :name="item.name"
      :price="item.price"
      :imgUrl="item.imgUrl"
      :-on-click-cart="() => deleteFromCart(item.product_id)"
    />
  </div>
</template>
<style scoped></style>
