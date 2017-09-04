<template>
    <div> 
        <side-nav></side-nav>
        <app-content></app-content>
    </div>
</template>

<script>
    import SideNav from './SideNav.vue';
    import AppContent from './AppContent.vue';
    export default {
        components: {SideNav, AppContent}
    }
</script>