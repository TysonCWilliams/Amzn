<template>
  <div class="about text-center">
    <h1>Welcome {{ profile.name }}</h1>
    <img class="rounded" :src="profile.picture" alt="" />
    <p>{{ profile.email }}</p>
    <h5>Add Product</h5>
    <form @submit.prevent="create(state.newProduct)">
      <div class="form-group">
        <label for="product-title">Product Title</label>
        <input type="text"
               class="form-control"
               id="product-title"
               aria-describedby="emailHelp"
               placeholder="Enter Title..."
               v-model="state.newProduct.title"
        >
      </div>
      <div class="form-group">
        <label for="description">Description</label>
        <input type="text" class="form-control" id="description" placeholder="Enter description" v-model="state.newProduct.body">
      </div>
      <div class="form-check">
        <input type="checkbox" class="form-check-input" id="isPublished" v-model="state.newProduct.isPublished">
        <label class="form-check-label" for="isPublished">Published?</label>
      </div>
      <button type="submit" class="btn btn-success">
        Submit
      </button>
    </form>
    <product v-for="product in products" :product-prop="product" :key="product.id" />
  </div>
</template>

<script>
import { computed, onMounted, reactive } from 'vue'
import { AppState } from '../AppState'
import { productsService } from '../services/ProductsService'
import { profileService } from '../services/ProfileService'
export default {
  name: 'Profile',
  setup() {
    onMounted(async() => {
      if (!AppState.profile.id) {
        await profileService.getProfile()
      }
      await productsService.getMyProducts()
    })
    const state = reactive({
      newProduct: {
        title: '',
        body: '',
        picture: '',
        isPublished: false
      }
    })
    return {
      state,
      create(newProduct) {
        // state.newProduct
        productsService.create(newProduct)
      },
      profile: computed(() => AppState.profile),
      products: computed(() => AppState.products)
    }
  }
}
</script>

<style scoped>
img {
  max-width: 100px;
}
</style>
