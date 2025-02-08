<script setup></script>
<template>
  <div
    class="flex flex-col md:grid grid-cols-2 2xl:grid-rows-[9fr_4fr] grid-rows-[2fr_1fr] gap-x-[30px] w-full work-sans text-text font-semibold"
  >
    <div class="flex flex-col w-full h-fit gap-5">
      <h1 class="h1 leading-tight">Discover digital art & Collect NFTs</h1>
      <p class="p font-light">
        NFT marketplace UI created with Anima for Figma. Collect, buy and sell art from more than
        20k NFT artists.
      </p>
    </div>
    <div class="row-span-2 w-full max-h-[500px] col-start-2 aspect-square">
      <img class="flex h-full mx-auto" src="/public/static/highlighted.gif" alt="highlighted" />
    </div>
    <div>
      <router-link :to="{ name: 'dev' }">
        <button
          class="my-[14px] xl:my-[30px] flex w-full md:w-fit sm:justify-self-center md:justify-self-start h-fit btn b py-4 px-8"
        >
          <img src="/public/icons/RocketLaunch.svg" alt="launch" />
          <p>Get started</p>
        </button>
      </router-link>

      <div class="flex flex-wrap justify-between">
        <h5 class="h5 w-1/3 space-mono">240k+</h5>
        <h5 class="h5 w-1/3 space-mono">240k+</h5>
        <h5 class="h5 w-1/3 space-mono">240k+</h5>
        <p class="w-1/3 work-sans">Total sales</p>
        <p class="w-1/3 work-sans">Auctions</p>
        <p class="w-1/3 work-sans">Artists</p>
      </div>
    </div>
  </div>
</template>
