<script setup>
    import { ref, watch } from "vue";
    import axios from "axios"

    const showAddModal = ref(false);
    const webUrl = "https://localhost:7236/api/TodoItems"
    const response = await axios.get(webUrl)
    const todoList = response.data
    let title = "";
    let note = "";
    let date = "";

    console.log(todoList);

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
        axios.delete(webUrl+"/id?id="+id)
        
        location.reload()
    }
</script>

<template>
    <main>
        <div v-if="showAddModal" class="overlay">
            <form @submit.prevent="addTodoItem(title, note)">
                <div class="modal">
                    <input v-model="title" name="title" type="text" placeholder="Enter a title.." />
                    <textarea v-model="note" name="note" cols="1" rows="5" placeholder="Description.."></textarea>
                    <input v-model="date" type="date"/>
                    <button type="submit">Add Todo</button>
                    <button @click="showAddModal = false" type="button" class="closeBtn">Close</button>
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
                        <h3>{{ todoItem.title }}</h3>
                        <p>{{ todoItem.note }}</p>
                        <p v-if="todoItem.todoDate">{{ todoItem.todoDate }}</p>
                        <input @click="deleteTodoItem(todoItem.id)" type="checkbox">
                    </div>
                </div>
            </div>
            <div v-if="todoList.length === 0">
                <h3>Add a todo..</h3>
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