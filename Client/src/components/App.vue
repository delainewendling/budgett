<template>
    <div> 
        <side-nav></side-nav>
    </div>
</template>

<script>
    import SideNav from './SideNav.vue';
    export default {
        data() {
            return {
                message: "Hello World"
            }
        },
        components: {SideNav}
    }
</script>