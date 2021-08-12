<template>
    <button @click="$emit('btn-click')" :style="{background:background, color: color}"  class="btn">{{ text }}</button>
</template>

<script>
    export default {
        name: "Button",
        props: {
            text: String,
            background: String,
            color: String
        },
        emits: ["btn-click"],
    }
</script>

<style scoped>
.btn {
    margin: 1%;
}
</style>