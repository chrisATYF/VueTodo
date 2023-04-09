<script setup>
    import { ref, vModelCheckbox } from "vue";
    import axios from "axios"

    const showModal = ref(false);
    const response = await axios.get("https://localhost:7236/api/TodoItems")
    const todoList = response.data
</script>

<template>
    <main>
        <div v-if="showModal" class="overlay">
            <div class="modal">
                <textarea class="todoItemTitle" name="todoTitle" id="todo" cols="1" rows="2" placeholder="Enter a title..."></textarea>
                <textarea name="todoItemNote" id="todo" cols="1" rows="10" placeholder="Description.."></textarea>
                <button>Add Todo</button>
                <button @click="showModal = false" class="closeBtn">Close</button>
            </div>
        </div>
        <div class="container">
            <header>
                <h1>Todo With Vue</h1>
                <button @click="showModal = true">+</button>
            </header>
            <div v-for="todoItem in todoList">
                <div v-if="!todoItem.isComplete" class="cards-container">
                    <div class="card">
                        <h4>{{ todoItem.title }}</h4>
                        <p class="main-text">{{ todoItem.note }}</p>
                    </div>
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
        font-size: 25px;
        color: white;
    }

    .card {
        width: 100%;
        height: 75px;
        background-color:darkgray;
        padding: 20px;
        border-radius: 15px;
        display: flex;
        flex-direction: row;
        justify-content: space-between;
        margin-bottom: 20px;
        color: black;
    }
    .cards-container {
        display: flex;
        flex-wrap: wrap;
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
        height: 300px;
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
        background-color: blue;
        border: none;
        color: white;
        cursor: pointer;
        margin-top: 15px;
        border-radius: 10px;
    }

    .modal .closeBtn {
        background-color: red;
        margin-top: 7px;
    }

    .modal textarea {
        resize: none;
    }
</style>