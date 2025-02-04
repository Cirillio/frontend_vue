<script setup>
import DrawerHead from './DrawerHead.vue'
import CartItemList from './CartItemList.vue'
import InfoBlock from './InfoBlock.vue'
import { inject, ref } from 'vue'

defineProps({
  totalPrice: Number,
  vatPrice: Number,
})
const { closeDrawer } = inject('cart')
const { makeOrder } = inject('cart')

const makingOrder = ref(false)

const onMakeOrder = async () => {
  makingOrder.value = true
  await makeOrder()
  makingOrder.value = false
}
</script>

<template>
  <div>
    <div
      @click="closeDrawer"
      class="fixed bg-black opacity-30 w-full h-full top-0 left-0 z-20"
    ></div>
    <div class="fixed w-96 h-full top-0 right-0 z-30 p-2 transition-all">
      <div class="flex flex-col h-full w-full bg-white p-5 rounded-xl shadow-xl">
        <DrawerHead />
        <div v-if="!totalPrice" class="flex flex-1" v-auto-animate>
          <InfoBlock
            title="Корзина пустая"
            info="Добавьте хотя бы один товар, чтобы сделать заказ"
            img-url="/package-icon.png"
          />
        </div>
        <div v-else class="overflow-y-scroll hide-scrollbar">
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
              @click="async () => await onMakeOrder()"
              :disabled="makingOrder"
              class="w-full bg-yellow-300 py-3 mt-2 rounded-xl transition-all hover:cursor-pointer hover:shadow-lg hover:bg-yellow-400 disabled:bg-slate-300"
            >
              <p>Заказать</p>
            </button>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>
<style></style>
