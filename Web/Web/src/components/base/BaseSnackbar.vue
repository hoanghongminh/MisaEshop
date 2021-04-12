<template>
  <div>
    <!--Snackbar thông báo thành công hay thất bại-->
    <div
      v-if="this.dataSnackBar.status == true"
      class="snackbar"
      :class="{ isShowSnackbar: isShowSnackbar }"
    >
      <i class="fas fa-check-circle"></i>
      <div class="snack-text">{{this.dataSnackBar.msg}}</div>
      <i class="fas fa-times"></i>
    </div>
    <div
      v-if="this.dataSnackBar.status == false"
      class="snackbar snackbar-errors"
      :class="{ isShowSnackbar: isShowSnackbar }"
    >
      <i class="fas fa-exclamation-triangle"></i>
      <div class="snack-text">{{this.dataSnackBar.msg}}</div>
      <i class="m-closeSnackBar-errors fas fa-times"></i>
    </div>
  </div>
</template>

<script>
// import $ from "jquery";
export default {
  name: "BaseSnackbar",
  data() {
    return {
      
    };
  },
  props: ["isShowSnackbar", "dataSnackBar"],
  methods: {
  },
};
</script>

<style>
@import "../../styles/basics/snackbar.css";
</style>