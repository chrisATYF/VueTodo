<script setup>
  import axios from "axios"
  import TodoData from "./data/data.json"

  const webUrlGetAll = "https://localhost:7236/api/TodoItems"
  const webUrlById = "https://localhost:7236/api/TodoItems/id?id=[todoId]"
  const webUrlAdd = ""
  const webUrlUpdate = ""
  const webUrlDelete = ""

  const response = axios.get(webUrlGetAll)
  const todoData = (await response).data;
</script>

<template>
  <main>
    <div class="container">
      <header>
        <h1>To Do List</h1>
        <button>+</button>
      </header>
      <div v-for="data in todoData" :key="data.id" class="card">
        <div v-if="!data.isComplete" class="container">
          <h4>{{ date.title }}</h4>
          <p>{{ data.note }}</p>
          <input type="checkbox" value="test" v-model="selected" @click="data.isComplete = true" />
        </div>
      </div>
    </div>
  </main>
</template>

<style scoped>
  main {
    height: 100vh;
    width: 100vw;
  }

  .container {
    max-width: 1000px;
    padding: 10px;
    margin: 0 auto;
  }

  header {
    display: flex;
    justify-content: space-between;
    align-items: center;
  }

  h1 {
    font-weight: bold;
    margin-bottom: 25px;
    font-size: 75px;
  }

  header button {
    border: none;
    padding: 10px;
    width: 50px;
    height: 50px;
    cursor: pointer;
    background-color: rgb(21, 20, 20);
    border-radius: 100%;
    color: white;
    font-size: 20px;
  }

  .overlay {
    position: absolute;
    width: 100%;
    height: 100%;
    background-color: rgba(0, 0, 0, 0.77);
    z-index: 10;
    display: flex;
    align-items: center;
    justify-content: center;
  }

  .modal {
    width: 750px;
    background-color: white;
    border-radius: 10px;
    padding: 30px;
    position: relative;
    display: flex;
    flex-direction: column;
  }
  
  .modal button {
    padding: 10px 20px;
    font-size: 20px;
    width: 100%;
    background-color: blueviolet;
    border: none;
    color: white;
    cursor: pointer;
    margin-top: 15px;
  }

  .modal .close {
    background-color: rgb(193, 15, 15);
    margin-top: 7px;
  }

  .modal p {
    color: rgb(193, 15, 15);
  }

  .todoCard {
    display: flex;
  }

  .todoCard h4 {
    padding: 0px 10px;
  }

  .card {
  /* Add shadows to create the "card" effect */
  box-shadow: 0 4px 8px 0 rgba(0,0,0,0.2);
  transition: 0.3s;
  }

  /* On mouse-over, add a deeper shadow */
  .card:hover {
    box-shadow: 0 8px 16px 0 rgba(0,0,0,0.2);
  }

  /* Add some padding inside the card container */
  .container {
    padding: 2px 16px;
  }
</style>