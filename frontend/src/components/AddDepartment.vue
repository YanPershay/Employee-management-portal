<template>
  <form @submit="onSubmit" class="add-form">
    <div class="form-control">

      <label> Department Name </label>
      <input
        type="text"
        v-model="departmentName"
        name="departmentName"
        placeholder="Add department"
      />
      <input
        type="submit"
        :value="isEdit ? 'Update' : 'Create'"
        :style="
           {
            background: isEdit ? 'blue' : 'green'
          }
        "
        class="btn btn-block btn-primary"
      />
    </div>
  </form>
</template>

<script>
export default {
  name: "AddDep",
  props: {
     departmentName: String,
     departmentId: Number,
     isEdit: Boolean
     //textedit: String,
     //color: String,
  },
  data() {
    return {
      //departmentName: "",
      //departmentId: 0,
      //textedit: false,
      //color: "yellow",
    };
  },
  methods: {
    onSubmit(e) {
      e.preventDefault();

      if (!this.departmentName) {
        alert('Please, add dep')
        return
      }

      const newDep = {
        id: this.departmentId,
        departmentName: this.departmentName
      }

      this.departmentName = ''
      this.departmentId = 0

      this.$emit('add-departament', newDep)
    },
  },
};
</script>

<style>
.add-form {
  margin-bottom: 40px;
  width: 50%;
  margin-left: 25%;
}
.form-control {
  margin: 20px 0;
}
.form-control label {
  display: block;
}
.form-control input {
  width: 100%;
  height: 40px;
  margin: 5px;
  padding: 3px 7px;
  font-size: 17px;
}
.form-control-check {
  display: flex;
  align-items: center;
  justify-content: space-between;
}
.form-control-check label {
  flex: 1;
}
.form-control-check input {
  flex: 2;
  height: 20px;
}
</style>