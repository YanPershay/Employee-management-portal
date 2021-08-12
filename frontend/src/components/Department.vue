<template>
  <div class="v-department">
    <Button
      @btn-click="toggleAddDep"
      :text="showAddDep ? 'Close' : 'Add department'"
      :background="showAddDep ? 'red' : 'green'"
      :color="'white'"
    />
    <div v-if="showAddDep">
      <!-- <AddDepartment
        @add-click="isEdit ? updateClick() : createClick()"
        :textedit="isEdit ? 'Edit' : 'Add'"
        :color="isEdit ? 'yellow' : 'blue'"
        :departmentName="departmentName"
        :departmentId="departmentId"
      /> -->
      <div v-if="isEdit">
        <AddDepartment
          v-show="showAddDep"
          @add-departament="updateClick"
          :departmentId="departmentId"
          :departmentName="departmentName"
          :isEdit="isEdit"
        />
      </div>
      <div v-else>
        <AddDepartment
          v-show="showAddDep"
          @add-departament="createClick"
          :departmentId="departmentId"
          :departmentName="departmentName"
          :isEdit="isEdit"
        />
      </div>
      <!-- :color="isEdit ? 'yellow' : 'blue'" -->
      <!-- :textedit="isEdit ? 'Edit' : 'Add'" -->
    </div>
    <div class="v-department__table">
      <table class="table table-stripped">
        <thead>
          <tr>
            <th>DepartmentId</th>
            <th>DepartmentName</th>
            <th>Options</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="dep in departments" :key="dep.Id">
            <td>
              {{ dep.Id }}
            </td>
            <td>
              {{ dep.DepartmentName }}
            </td>
            <td>
              <button
                type="button"
                class="btn btn-light mr-1"
                @click="editClick(dep)"
              >
                <svg
                  xmlns="http://www.w3.org/2000/svg"
                  width="16"
                  height="16"
                  fill="currentColor"
                  class="bi bi-pencil-square"
                  viewBox="0 0 16 16"
                >
                  <path
                    d="M15.502 1.94a.5.5 0 0 1 0 .706L14.459 3.69l-2-2L13.502.646a.5.5 0 0 1 .707 0l1.293 1.293zm-1.75 2.456-2-2L4.939 9.21a.5.5 0 0 0-.121.196l-.805 2.414a.25.25 0 0 0 .316.316l2.414-.805a.5.5 0 0 0 .196-.12l6.813-6.814z"
                  />
                  <path
                    fill-rule="evenodd"
                    d="M1 13.5A1.5 1.5 0 0 0 2.5 15h11a1.5 1.5 0 0 0 1.5-1.5v-6a.5.5 0 0 0-1 0v6a.5.5 0 0 1-.5.5h-11a.5.5 0 0 1-.5-.5v-11a.5.5 0 0 1 .5-.5H9a.5.5 0 0 0 0-1H2.5A1.5 1.5 0 0 0 1 2.5v11z"
                  />
                </svg>
              </button>
              <button type="button" class="btn btn-danger mr-1" @click="deleteClick(dep.Id)">
                <svg
                  xmlns="http://www.w3.org/2000/svg"
                  width="16"
                  height="16"
                  fill="currentColor"
                  class="bi bi-trash-fill"
                  viewBox="0 0 16 16"
                >
                  <path
                    d="M2.5 1a1 1 0 0 0-1 1v1a1 1 0 0 0 1 1H3v9a2 2 0 0 0 2 2h6a2 2 0 0 0 2-2V4h.5a1 1 0 0 0 1-1V2a1 1 0 0 0-1-1H10a1 1 0 0 0-1-1H7a1 1 0 0 0-1 1H2.5zm3 4a.5.5 0 0 1 .5.5v7a.5.5 0 0 1-1 0v-7a.5.5 0 0 1 .5-.5zM8 5a.5.5 0 0 1 .5.5v7a.5.5 0 0 1-1 0v-7A.5.5 0 0 1 8 5zm3 .5v7a.5.5 0 0 1-1 0v-7a.5.5 0 0 1 1 0z"
                  />
                </svg>
              </button>
            </td>
          </tr>
        </tbody>
      </table>
    </div>
  </div>
</template>

<script>
import Button from "./Button.vue";
import AddDepartment from "./AddDepartment.vue";
import axios from "axios";
import variables from "../variables";

export default {
  name: "Department",
  props: {
    showAddDep: {
      type: Boolean,
      default: false,
    },
  },
  components: {
    Button,
    AddDepartment,
  },
  data() {
    return {
      departments: [],
      isEdit: false,
    };
  },
  methods: {
    refreshData() {
      axios.get(variables.API_URL + "departments").then((response) => {
        this.departments = response.data;
      });
    },
    toggleAddDep() {
      this.isEdit = false;
      this.departmentName = "";
      this.departmentId = 0;
      this.showAddDep = !this.showAddDep;
    },
    editClick(dep) {
      if (!this.showAddDep) {
        this.showAddDep = !this.showAddDep;
      }
      this.isEdit = true;
      this.departmentName = dep.DepartmentName;
      this.departmentId = dep.Id;
    },
    async createClick(department) {
      await fetch(variables.API_URL + "departments", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(department),
      });

      this.refreshData();

      this.isEdit = false;
      this.departmentName = "";
      this.departmentId = 0;
      this.showAddDep = !this.showAddDep;
    },
    async updateClick(department) {
      await fetch(variables.API_URL + "departments", {
        method: "PUT",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(department),
      });

      this.refreshData();
      this.isEdit = false;
      this.departmentName = "";
      this.departmentId = 0;
      this.showAddDep = !this.showAddDep;
    },
    async deleteClick(id) {
      await fetch(variables.API_URL + `departments/${id}`, {
        method: "DELETE",
        headers: {
          "Content-Type": "application/json",
        }
      });

      this.refreshData();
    },
  },
  mounted() {
    this.refreshData();
  },
};
</script>

<style lang="scss">
.v-department {
  font-family: Arial, Helvetica, sans-serif;
  font-size: 100%;
}

@import "~bootstrap/dist/css/bootstrap.css";
</style>