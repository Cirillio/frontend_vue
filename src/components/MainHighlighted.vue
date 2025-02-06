<script setup></script>
<template>
  <div
    class="flex flex-col sm:grid grid-cols-2 grid-rows-2 gap-x-[30px] w-full px-10 md:px-20 xl:px-56 text-text work-sans font-semibold"
  >
    <div class="flex flex-col w-full h-fit gap-5">
      <h1 class="h1 leading-tight">Discover digital art & Collect NFTs</h1>
      <p class="p">
        NFT marketplace UI created with Anima for Figma. Collect, buy and sell art from more than
        20k NFT artists.
      </p>
    </div>
    <div class="row-span-2 w-full col-start-2 aspect-square">
      <img class="flex w-full" src="/public/static/highlighted.gif" alt="highlighted" />
    </div>
    <div>
      <button
        class="my-[14px] xl:my-[30px] flex w-full sm:w-fit sm:justify-self-center md:justify-self-start h-fit btn b py-4 px-8"
      >
        <img src="/public/icons/RocketLaunch.svg" alt="launch" />
        <p>Get started</p>
      </button>
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
