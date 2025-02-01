<script setup>
import CartItem from './CartItem.vue'

import { inject } from 'vue'

const { cart } = inject('cart')
</script>

<template>
  <div class="flex flex-col grow overflow-y-scroll hide-scrollbar my-5 gap-2">
    <CartItem v-for="item in cart" :key="item.id" :name="item.name" />
  </div>
</template>
<style scoped></style>
