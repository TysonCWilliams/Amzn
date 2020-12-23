<template>
  <div class="productComponent card p-2 shadow-lg border border-primary rounded">
    <h1>
      {{ product.title }}
    </h1>
  </div>
</template>

<script>
  import { computed } from 'vue'
  export default {
    name: 'ProductComponent',
    props: ['productProp'],
    setup(props) {
      return {
        product: computed(() => props.productProp)
      }
    },
    components: {}
  }
</script>

<style lang="scss" scoped>
</style>
