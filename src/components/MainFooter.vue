<script setup>
import MainLogo from "./MainLogo.vue";
</script>
<template>
  <footer
    class="w-full mt-auto flex flex-col gap-8 text-desc bg-backgroundSecond py-10 px-6 xl:px-40 2xl:px-60"
  >
    <div class="flex flex-col lg:flex-row md:mx-8 font-light gap-16">
      <div class="work-sans flex flex-1 flex-col gap-5">
        <router-link :to="{ name: 'MainPage' }"> <MainLogo class="text-text" /> </router-link>
        <p>NFT marketplace UI created with Anima for Figma.</p>
        <p>Join our community</p>
        <div class="flex gap-2">
          <a href="#"><img src="/public/icons/DiscordLogo.svg" alt="discord_logo" /></a>
          <a href="#"><img src="/public/icons/YoutubeLogo.svg" alt="youtube_logo" /></a>
          <a href="#"><img src="/public/icons/TwitterLogo.svg" alt="twitter_logo" /></a>
          <a href="#"><img src="/public/icons/InstagramLogo.svg" alt="instagram_logo" /></a>
        </div>
      </div>
      <div class="flex flex-1 flex-col gap-5 [&>*>*]:hover:underline">
        <h5 class="h5 space-mono max-h-[30px] text-text">Explore</h5>
        <router-link :to="{ name: 'Marketplace' }">
          <p>Marketplace</p>
        </router-link>
        <router-link :to="{ name: 'dev' }">
          <p>Rankings</p>
        </router-link>
        <router-link :to="{ name: 'dev' }">
          <p>Connect a wallet</p>
        </router-link>
      </div>
      <div class="flex flex-2 flex-col gap-5">
        <h5 class="h5 space-mono text-text">Join Our Weekly Digest</h5>
        <p class="work-sans lg:pr-32 font-light">
          Get exclusive promotions & updates straight to your inbox.
        </p>
        <div class="h-fit w-full lg:w-fit relative flex flex-col gap-5">
          <input
            type="text"
            class="2-full h-full w-full py-5 pl-5 pr-5 md:pr-44 text-black work-sans rounded-[20px] bg-white focus:outline-none"
          />
          <button
            class="btn b font-semibold work-sans text-text h-full px-10 md:absolute md:w-fit w-full p-5 top-0 right-0"
          >
            Subscribe
          </button>
        </div>
      </div>
    </div>
    <p class="c pt-5 border-t font-light border-desc">
      Ⓒ NFT Market. Original template:
      https://www.figma.com/design/Uy9znCXGkQ3p8vYQeq8OjF/NFT-Marketplace-Template---Create-an-NFT-website-in-minutes-(Community)?node-id=1647-17907&t=663ogRs2G2pZOxbd-1
    </p>
  </footer>
</template>
