<style>
    .menu {
        position: fixed;
        width: 60px;
        height: 900px;
        background-color: #153b50;
    }
    li {
        padding-left: 20px;
    }
    li.active {
        width: 60px;
        height: 55px;
        background-color: rgba(255, 255, 255, 0.2);
    }
    ul {
        padding: 0;
    }
    .budgett-logo {
        margin-top: 30px;
        padding-left: 3px;
        height: 20px;
        width: 17px;
    }
    .insights-icon {
        margin-top: 81px;
    }
    .sidebar-icon {
        display: block;
        width: 30px;
    }
    svg {
        display: block;
        margin-left: 20px;
    }
</style>

<template>
    <nav class="menu">
        <ul>
            <li>
                <img class="budgett-logo" src="../../images/BudgettLogo.png">
            </li>
            <li :class="{active: route === '/insights', 'sidebar-icon': true, 'insights-icon': true}" @click="changeActive('/insights')">
                <a href="/#/insights">
                    <img src="../../images/InsightsIcon.png">
                </a>
            </li>
            <li :class="{active: route === '/transactions', 'sidebar-icon': true}" class="sidebar-icon" @click="changeActive('/transactions')">
                <a href="/#/transactions">
                    <img src="../../images/TransactionsIcon.png">
                </a>
            </li>
            <li :class="{active: route === '/settings', 'sidebar-icon': true}" class="sidebar-icon" @click="changeActive('/settings')">
                <a href="/#/settings">
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