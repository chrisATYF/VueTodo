<script setup>
import { ref } from "vue";
import axios from "axios"

const showAddModal = ref(false);
const webUrl = "https://localhost:7236/api/TodoItems"
const response = await axios.get(webUrl)
const todoList = response.data
let title = "";
let note = "";
let date = "";

function addTodoItem() {
    axios.post(webUrl, {
        id: 0,
        title: title,
        note: note,
        todoDate: date,
        isComplete: false
    })

    title = "";
    note = "";
    date = "";

    location.reload()
}

function deleteTodoItem(id) {
    axios.delete(webUrl + "/id?id=" + id)

    location.reload()
}
</script>

<template>
    <div v-if="showAddModal" class="overlay">
        <form @submit.prevent="addTodoItem(title, note)">
            <div class="modal">
                <input v-model="title" name="title" type="text" placeholder="Enter a title.." style="margin: 5px;" />
                <textarea v-model="note" name="note" cols="1" rows="4" placeholder="Description.." style="margin: 5px;"></textarea>
                <input v-model="date" type="date" style="margin: 5px;" />
                <div class="buttonContainer">
                    <button type="submit">Add Todo</button>
                    <button @click="showAddModal = false" type="button" class="closeBtn">Close</button>
                </div>
            </div>
        </form>
    </div>
    <div class="container">
        <header>
            <h1>Todo With Vue</h1>
            <button @click="showAddModal = true">+</button>
        </header>
        <div v-for="todoItem in todoList" :key="todoItem.id">
            <div v-if="!todoItem.isComplete" class="cards-container">
                <div class="card">
                    <h3 class="todoTitle">{{ todoItem.title }}</h3>
                    <p class="todoNote">{{ todoItem.note }}</p>
                    <p class="todoDate" v-if="todoItem.todoDate">{{ todoItem.todoDate }}
                        <input @click="deleteTodoItem(todoItem.id)" type="checkbox">
                    </p>
                </div>
            </div>
        </div>
        <div v-if="todoList.length === 0">
            <h3>Add a todo..</h3>
        </div>
    </div>
</template>

<style scoped>
.container {
    max-width: 1000px;
    padding: 10px;
    margin: 0 auto;
}

header {
    display: flex;
    justify-content: space-between;
    align-items: center;
    color: rgb(91, 192, 235);
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
    background-color: rgb(42, 43, 42);
    border-radius: 100%;
    font-size: 25px;
    color: white;
}

.card {
    width: 100%;
    height: 75px;
    background-color: rgba(0, 0, 0, 0);
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
    background-color: rgb(132, 145, 163);
    border-radius: 10px;
    padding: 20px;
    position: relative;
    display: flex;
    flex-direction: column;
}

.modal button {
    padding: 10px 20px;
    font-size: 20px;
    width: 100%;
    background-color: rgb(202, 223, 158);
    border: none;
    color: white;
    cursor: pointer;
    margin-top: 15px;
    border-radius: 10px;
}

.modal .closeBtn {
    background-color: rgb(240, 84, 79);
    margin-top: 7px;
}

.modal textarea {
    resize: none;
}

.todoTitle, .todoDate {
    height: 100%;
    width: 25%;
    background-color: rgb(91, 192, 235);
    border-radius: 15px;
    padding: 20px;
    text-align: center;
}

.todoNote{
    height: 100%;
    width: 100%;
    padding: 20px;
    border-radius: 15px;
    text-align: center;
    background-color: rgb(132, 145, 163);
}
</style>