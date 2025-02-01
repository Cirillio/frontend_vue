<script setup>
import DrawerHead from './DrawerHead.vue'
import CartItemList from './CartItemList.vue'
import { inject } from 'vue'

const props = defineProps({
  totalPrice: Number,
  vatPrice: Number,
})

const { closeDrawer } = inject('cart')
</script>

<template>
  <div @click="closeDrawer" class="fixed bg-black opacity-30 w-full h-full top-0 left-0 z-10"></div>
  <div class="fixed w-96 h-full top-0 right-0 z-20 p-2 transition-all">
    <div class="flex flex-col h-full w-full bg-white p-5 rounded-xl shadow-xl">
      <DrawerHead />
      <CartItemList />
      <div class="flex flex-col gap-2">
        <div class="flex gap-2 items-baseline">
          <p>Итого:</p>
          <div class="grow border-b border-dashed"></div>
          <b>{{ totalPrice }}р.</b>
        </div>
        <div class="flex items-baseline gap-2">
          <p>НДС (5%):</p>
          <div class="grow border-b border-dashed"></div>
          <b>{{ vatPrice }}р.</b>
        </div>
        <button
          disabled=""
          class="w-full bg-yellow-300 py-3 mt-2 rounded-xl transition-all hover:cursor-pointer hover:shadow-lg hover:bg-yellow-400 disabled:bg-slate-300"
        >
          <p>Заказать</p>
        </button>
      </div>
    </div>
  </div>
</template>
<style></style>
