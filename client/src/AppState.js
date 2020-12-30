import { reactive } from 'vue'
// eslint-disable-next-line no-unused-vars
// import Product from './models/Product'
// eslint-disable-next-line no-unused-vars
// import Wishlist from './models/Wishlist'

// NOTE AppState is a reactive object to contain app level data
export const AppState = reactive({
  user: {},
  profile: {},
  // /** @type { Product[] } */
  products: []
  // /** @type { Wishlist[] } */
  // wishlists: []
})
