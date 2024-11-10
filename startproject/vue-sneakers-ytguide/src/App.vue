<script setup>
import productCard from './components/productCard.vue'
</script>

<template>
  <!-- тут прописаны пропсы-->
  <!-- : - означает что значение пропса передается в нужном типе (строка, число, булевое) -->
  <!-- если пропс написан кемелкейсом то его можно написать в кебабкейсе - так советуют делать -->
  <!-- во внутрь компонента можно прокинуть еще что угодно если в нем есть слот - <slot></slot> -->
  <productCard name="" :price="129000" :isAddedd="false">
    <button>Купить</button>
  </productCard>
  <productCard name="Iphone 11" :price="100000" is-added>
    <button>Продать</button>
  </productCard>
</template>

<style>
* {
  margin: 0;
  padding: 0;
  box-sizing: border-box;
}

body {
  background: #cecece;
}
</style>
