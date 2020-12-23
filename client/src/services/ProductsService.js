import { logger } from '../utils/Logger'
import { api } from './AxiosService'
import { AppState } from '../AppState'

class ProductsService {
  async getPublicProducts() {
    try {
      const res = await api.get('api/products')
      logger.log(res.data)
      AppState.products = res.data
    } catch (error) {
      logger.error(error)
    }
  }

  async create(newProduct) {
    try {
      await api.post('api/products', newProduct)
      this.getMyProducts()
    } catch (error) {
      logger.log(error)
    }
  }

  async getMyProducts() {
    try {
      logger.log(AppState.profile)
      const res = await api(`profile/${AppState.profile.id}/products`)
      AppState.products = res.data
      // NOTE dont forget to add your js doc types in the appstate
      // AppState.products = res.data.map(e => new Product(e.title, e.body))
      // this now has intellisense on 'p' AppState.products.forEach(p=> p.)
    } catch (error) {
      logger.error(error)
    }
  }
}

export const productsService = new ProductsService()
