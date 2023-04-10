<script setup>
  import TodoList from "./components/TodoList.vue"
</script>

<template>
  <main>
    <Suspense>
      <TodoList></TodoList>
    </Suspense>
  </main>
</template>

<style scoped>
  main {
    height: 100vh;
    width: 100vw;
  }
</style>