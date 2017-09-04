<style>
    .menu {
        position: fixed;
        width: 60px;
        height: 900px;
        background-color: #153b50;
    }
    li.active {
        width: 60px;
        height: 55px;
        background-color: rgba(255, 255, 255, 0.2);
    }
    ul {
        margin-top: 150px;
        padding: 0;
    }
    svg {
        display: block;
        margin-left: 20px;
    }
</style>

<template>
    <nav class="menu">
        <ul>
            <li :class="{active: route === '/insights'}" @click="changeActive('/insights')">
                <a href="/insights">
                    <img src="../../images/InsightsIcon.png">
                </a>
            </li>
            <li :class="{active: route === '/transactions'}" @click="changeActive('/transactions')">
                <a href="/transactions">
                    <img src="../../images/TransactionsIcon.png">
                </a>
            </li>
            <li :class="{active: route === '/settings'}" @click="changeActive('/settings')">
                <a href="/settings">
                    <img src="../../images/SettingsIcon.png">
                </a>
            </li>
        </ul>
    </nav>
</template>

<script>
export default {
    data(){
        return {
            route: this.$route.path
        }
    },
    methods: {
        changeActive(route){
            this.route = route;
        }
    }
}
</script>