<script setup>
import DrawerHead from './DrawerHead.vue'
import CartItemList from './CartItemList.vue'
</script>

<template>
  <div class="fixed bg-black opacity-30 w-full h-full top-0 left-0 z-10"></div>
  <div class="fixed w-96 h-full top-0 right-0 z-20 p-2 transition-all">
    <div class="h-full w-full bg-white p-5 rounded-xl shadow-xl">
      <DrawerHead />
      <CartItemList />
      <div class="flex flex-col gap-2 self-end">
        <div class="flex justify-between gap-2 items-baseline">
          <p class="text-nowrap">Итого:</p>
          <div class="flex w-full border-b border-dashed border-black opacity-20"></div>
          <b>12990р.</b>
        </div>
        <div class="flex justify-between items-baseline gap-2">
          <p class="text-nowrap">НДС (5%):</p>
          <div class="flex w-full border-b border-dashed border-black opacity-20"></div>
          <b>649,5р.</b>
        </div>
      </div>
      <button
        class="w-full bg-yellow-300 items-center justify-center text-lg text-black p-2 mt-5 rounded-xl transition-all hover:shadow-lg hover:bg-yellow-400"
      >
        <p>Заказать</p>
      </button>
    </div>
  </div>
</template>
<style></style>
