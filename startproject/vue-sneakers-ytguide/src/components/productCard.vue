<script setup>
// setup - определяет синтаксис Vue 3
// Composition API
// без setup - определяет синтаксис Options API

//ref - реактивное свойство для переменной примитивного типа
// reactive - реактивное свойство для переменной объектного типа

// defineProps - определяет свойства компонента
// входящие в него в виде объекта из пропсов в родительском компоненте
const card = defineProps({
  name: String,
  price: Number,
  isAdded: Boolean,
})
</script>

<template>
  <!-- <h1>{{ count }}</h1>
  <button @click="increment">+</button>
  <input type="text" @keydown.up="increment" @keydown.down="decrement" />
  вью понимает что каунт изменился и перерисовывает -->

  <div class="product">
    <h2>Товар: {{ name === '' ? 'no name' : name }}</h2>
    <h3>Цена: {{ card.price }}</h3>
    <h4>Добавлен в корзину: {{ isAdded ? 'да' : 'нет' }}</h4>

    <slot></slot>
  </div>
</template>

<!-- scoped - означает что стили применятся только к этому компоненту -->
<style scoped>
.product {
  width: 360px;
  height: 180px;
  padding: 10px;
  border: 1px solid #808080;
  border-radius: 5px;
}

.product h2,
h3 {
  color: #032a6d;
  display: block;
  background: #939393;
  border-radius: 9px;
  padding: 10px;
  margin: 10px 0;
}
</style>
