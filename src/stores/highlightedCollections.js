import { defineStore } from "pinia";
import url from "../config.js";
import axios from "axios";

// хранилище коллекций, показываемых на главной странице
export const useHighlightedCollectionsStore = defineStore("highlightedCollections", {
  state: () => ({
    trending_collections: [],
    highlighted_collections: [],
    isLoading: false,
    error: null,
  }),
  actions: {
    async fetchHighlighted() {
      this.isLoading = true;
      this.error = null;
      try {
        const { data: trendings } = await axios.get(url.trendingCollectionsUrl + "?sortBy=-rating");
        if (trendings.length === 0) return;
        this.trending_collections = trendings.slice(0, 3);
        // console.log(this.isLoading);

        // console.table(this.trending_collections);

        let collections_id = "";
        this.trending_collections.forEach((item) => {
          collections_id += "id=" + item.collection_id + "&";
        });

        const { data: collections } = await axios.get(
          url.collectionsUrl + "?" + collections_id + "_relations=artists" // получаю художника по artist_id в объекте collection (полученный объект artist заменяет поле artist_id)
        );

        // console.table(collections);

        ///////////////

        const allNftIds = collections.flatMap((collection) => collection.nfts); // формирую массив из всех нфт полученных коллекций
        const uniqueNftIds = [...new Set(allNftIds)]; // удаляю дубликаты
        let nfts_id = "";

        uniqueNftIds.forEach((nft) => {
          nfts_id += "id=" + nft + "&";
        }); // формирую строку для запроса нужных нфт

        const { data: nfts } = await axios.get(url.nftsUrl + "?" + nfts_id + "_select=id,img"); // получаю ид и имг нужных нфт

        // console.log(nfts);
        //////////////

        this.highlighted_collections = collections.map((collection) => ({
          // формирую итоговый массив выделенных коллекций для главной страницы
          ...collection,
          nfts: collection.nfts
            .map((nftId) => nfts.find((nft) => nft.id === nftId))
            .filter(Boolean) // Фильтруем возможные undefined
            .slice(0, 3),
          remaining: Math.max(collection.nfts.length - 3, 0),
        }));

        ///////////////

        // console.table(this.highlighted_collections);

        console.log("highlightings successfully loaded");
      } catch (error) {
        this.error = error.message;
        console.error(error);
      } finally {
        this.isLoading = false;
      }
    },
  },
});
