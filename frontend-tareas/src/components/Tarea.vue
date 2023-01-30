<template>
    <div class="aplication">
      <h2 class="display-4 text-center">To-Do List✔️</h2>
      <hr>
      <div class="row">
        <div class="col-md-12 col-sm-12 col-lg-12">
          <div class="card mt-4">
            <div class="card-body">
              <div class="input-group">
                <input type="text" class="form-control form-control-lg" placeholder="Agregar Tarea" v-model="tarea">
                <div class="input-group-append">
                  <button class="btn btn-success btn-lg" v-on:click="agregarTarea()" >Agregar</button>
                </div>
              </div>
              <br>
              <h5 v-if="listTareas.length == 0">No hay tareas para realizar🤟</h5>
              <ul class="list-group">
                <li v-for="(tarea, index) of listTareas" :key="index"
                    class="list-group-item d-flex justify-content-between">
                    <span class="cursor" v-bind:class="{'text-success' : tarea.estado}" v-on:click="editarTarea(tarea, tarea.id)">
                        <i v-bind:class="[tarea.estado ? 'fa-solid fa-circle-check' : 'fa-regular fa-circle']"></i>
                        
                    </span>
                    {{ tarea.nombre }}

                  
                    <span class="text-danger cursor" v-on:click="eliminarTarea(tarea.id)">
                        <i class="fa-solid fa-trash-can"></i>
                    </span>
                </li>
              </ul>
            </div>
          </div>
        </div>
      </div>
    </div>
  </template>

<script>
import axios from "axios";
const URL = "https://backend-tareas20230130124743.azurewebsites.net/api/Tarea/"
    export default {
        name: 'Tarea-todo',
        data(){
            return{
                tarea:'',
                listTareas: []
            }
        },
        methods:{
            agregarTarea(){
                const tarea = {
                    nombre: this.tarea,
                    estado: false
                }
                axios.post(URL , tarea).then(response => {
                    console.log(response);
                    this.obtenerTareas();
                }).catch(error =>{
                    console.log(error);
                });
                /*this.listTareas.push(tarea)*/
                this.tarea = '';
            },
            eliminarTarea(id){
                axios.delete(URL + id).then(response => {
                    console.log(response);
                    this.obtenerTareas();
                }).catch(error => {
                    console.log(error)
                });
                /*this.listTareas.splice(index, 1)*/
            },
            editarTarea(tarea, id){
                /*this.listTareas[index].estado = !tarea.estado*/
                axios.put(URL + id, tarea).then(response=>{
                    console.log(response);
                    this.obtenerTareas();          
                }).catch(error =>{
                    console.log(error)
                });

            },
            obtenerTareas(){
              axios.get(URL).then(response =>{
                console.log(response);
                this.listTareas = response.data;
              })
            }
        },
        created: function(){
          this.obtenerTareas();
        }
    }
</script>

<style scoped>
.cursor {
    cursor: pointer;
}
</style>