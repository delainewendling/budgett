<style>
    .menu {
        position: fixed;
        width: 60px;
        height: 100%;
        background-color: #153b50;
        z-index: 2000;
        display: block;
    }

    li {
        padding-left: 16px;
        padding-right: 17px;
        padding-bottom: 10px;
    }

    li.active {
        padding-left: -4px;
        width: 60px;
        height:75px;
        background-color: rgba(255, 255, 255, 0.2);
    }

    ul {
        padding: 0px;
    }

    .budgett-logo {
        margin-top: 30px;
        margin-left: 4px;
        height: 20px;
        width: 20px;
        margin-bottom: 40px;
    }

    .sidebar-icon {
        display: block;
        width: 26px;
        padding-top: 14px;
    }

    .insights-icon {
        width: 28px;
        padding-top: 14px;
    }


</style>

<template>
    <div>
        <nav class="menu">
            <ul>
                <li>
                    <img class="budgett-logo" src="../../images/BudgettLogo.png">
                </li>

                <li :class="{active: route === '/insights', 'sidebar-icon': true, 'insights-icon': true}" @click="changeActive('/insights')">
                    <a href="/#/insights">
                        <img src="../../images/InsightsIcon.png" class='insights-icon'>
                    </a>
                </li>

                <li :class="{active: route === '/transactions', 'sidebar-icon': true}" class="sidebar-icon" @click="changeActive('/transactions')">
                    <a href="/#/transactions">
                        <img src="../../images/TransactionsIcon.png" class='sidebar-icon'>
                    </a>
                </li>

                <li :class="{active: route === '/settings', 'sidebar-icon': true}" class="sidebar-icon" @click="changeActive('/settings')">
                    <a href="/#/settings">
                        <img src="../../images/SettingsIcon.png" class='sidebar-icon'>
                    </a>
                </li>
            </ul>
        </nav>
    </div>
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