<template>
     <div class="row">
        <transaction-list></transaction-list>
        <transaction-content></transaction-content>
    </div>
</template>

<script>
import TransactionList from './TransactionList.vue';
import TransactionContent from './TransactionContent.vue';
export default {
    components: { TransactionList, TransactionContent }
}
</script>
