<template>
  <div class="home flex-grow-1 d-flex flex-column align-items-center justify-content-center">
    <img src="https://bcw.blob.core.windows.net/public/img/8600856373152463" alt="CodeWorks Logo">
    <h1 class="my-5 bg-dark text-light p-3 rounded d-flex align-items-center">
      <span class="mx-2 text-white">Vue 3 Starter</span>
    </h1>
    <!-- products -->
    <product v-for="product in products" :product-prop="product" :key="product.id" />
  </div>
</template>

<script>
  import { computed, onMounted } from 'vue'
  import { productsService } from '../services/ProductsService'
  import { AppState } from '../AppState'
  export default {
    name: 'Home',
    setup() {
      onMounted(() => {
        productsService.getPublicProducts()
      })
      return {
        products: computed(() => AppState.products)
      }
    }
  }
</script>

<style scoped lang="scss">
  .home {
    text-align: center;
    user-select: none;
  }

  img {
    height: 200px;
    width: 200px;
  }
</style>
