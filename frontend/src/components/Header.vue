<template>
    <div class="v-header">
        <h1 class="d-flex justify-content-center">
                {{pageName}}
        </h1>
    </div>
</template>

<script>
    export default {
        name: "Header",
        data() {
            return {

            }
        },
        props: {
            pageName: {
                type: String,
                default: "Employee management"
            }
        }
    }
</script>

<style lang="scss">
    .v-header {
        align-items: center;
        position: fixed;
        width: 100%;
        top: 0;
        left:0;
        font-family: Arial, Helvetica, sans-serif;
        font-size: 150%;
        margin: 30px;
    }
</style>