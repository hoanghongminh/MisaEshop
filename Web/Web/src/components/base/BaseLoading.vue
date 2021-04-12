<template>
    <div>
        <Loading 
        :active.sync="showLoading"
        :loader="loader"
        :color="color"
        :height="height"
        :width="width"
        :opacity="opacity"
        :background-color="backgroundColor"
        :blur="blur"
        :is-full-page="fullPage">
      </Loading>
    </div>
</template>

<script>
    // Import component
import Loading from 'vue-loading-overlay';
    // Import stylesheet
import 'vue-loading-overlay/dist/vue-loading';
    
    export default {
        name: "BaseLoading",
       
        components: {
            Loading
        },
        props:["showLoading"],
        methods: {
            
        },
        data() {
            return {
            isLoading: false,
            color: "#019160",
            loader: "dots", // bars  dots spinner
            width: 50,
            height: 50,
            backgroundColor: "#000",
            fullPage: false,
            opacity: 0.3,
            isHideParent: true,
            blur: "15px",
            
            };
        },
    };
</script> 