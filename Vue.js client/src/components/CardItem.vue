<script setup>
import { ref, defineEmits } from 'vue'

import axios from 'axios'

const props = defineProps({
  title: String,
  price: Number,
  img: String,
  amount: {
    type: Number,
    default: 0,
  },
})
const emit = defineEmits()
const amountRef = ref(props.amount)

function checkInput(event) {
  const value = Number(event.target.value)
  if (isNaN(value) || value < 0) {
    event.target.value = ''
  } else {
    amountRef.value = value
  }
}
function addAmount() {
  amountRef.value++
}
function removeAmount(event) {
  amountRef.value--
  if (amountRef.value <= 0) {
    event.target.parentElement.classList.add('hidden')
    const addBtn = event.target.parentElement.parentElement.querySelector('.addToCart')
    addBtn.classList.remove('hidden')
    return
  }
}

function addToCart(event) {
  addAmount()
  addCartItem()
  event.target.classList.add('hidden')
  const amount = event.target.parentElement.querySelector('.addAmount')
  amount.classList.remove('hidden')
}

const addCartItem = async () => {
  try {
    const cartItem = { ...props, amount: amountRef.value }
    const response = await axios.post('http://localhost:5154/api/cart', cartItem)

    if (response.status === 200) {
      emit('itemAdded', response.data)
      console.log('Item added to cart successfully:', response.data)
    } else {
      console.warn('Unexpected response status:', response.status)
    }
  } catch (error) {
    console.error('Error adding item to cart:', error)
  }
}
</script>

<template>
  <div
    class="bg-white font-Source w-auto max-h-48 items-center flex flex-col gap-4 relative rounded-md border-slate-500 p-6 transition-all hover:shadow-md"
  >
    <button
      class="absolute top-2 right-2 opacity-20 w-4 cursor-pointer transition-all hover:-translate-y-1"
    >
      <img class="select-none pointer-events-none" src="/icons/edit.svg" alt="edit" />
    </button>

    <div class="addAmount absolute flex hidden bottom-7 right-3 w-fit cursor-pointer bg-black">
      <button @click="removeAmount" class="w-2 bg-slate-100"><</button>
      <input
        @input="checkInput"
        type="text"
        class="w-6 text-center bg-slate-200 text-xs focus:outline-none"
        :value="amountRef"
      />
      <button @click="addAmount" class="w-2 bg-slate-100">></button>
    </div>

    <button
      @click="addToCart"
      class="addToCart absolute flex bottom-6 right-2 w-10 cursor-pointer contrast-100 transition-all hover:contrast-75"
    >
      <img class="select-none pointer-events-none" src="/icons/plus.svg" alt="add" />
    </button>

    <div class="w-full items-center justify-center flex aspect-square overflow-hidden">
      <img class="select-none h-full" :src="img" alt="prodimg" />
    </div>

    <div class="flex flex-col w-4/5 text-sm self-start">
      <p>{{ title }}</p>
      <p>{{ price }}</p>
    </div>
  </div>
</template>

<style></style>
