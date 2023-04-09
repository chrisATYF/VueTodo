<script setup>
  import CardList from "./components/CardList.vue"
</script>

<template>
  <main>
    <Suspense>
      <CardList></CardList>
    </Suspense>
  </main>
</template>

<style scoped>
  main {
    height: 100vh;
    width: 100vw;
  }
</style>