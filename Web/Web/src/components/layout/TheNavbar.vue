<template>
  <div>
    <!-- Navbar -->
    <div class="navbar">
      <div class="logo-site">
        <!-- Logo -->
        <div class="logo-box">
          <div class="cukcuk-logo"></div>
        </div>
      </div>
      <!-- Danh mục navbar -->
      <div class="navbar-content">
        <div class="nav-item">
          <div class="nav-item-icon m-icon-dashboard"></div>
          <div class="nav-item-text">Tổng quan</div>
        </div>
        <div class="nav-item">
          <div class="nav-item-icon m-icon-report"></div>
          <div class="nav-item-text">Báo cáo</div>
        </div>
        <div class="nav-item">
          <div class="nav-item-icon m-icon-document"></div>
          <div class="nav-item-text">Đơn hàng</div>
        </div>
        <div class="nav-item">
          <div class="nav-item-icon m-icon-store"></div>
          <div class="nav-item-text">Mua hàng</div>
        </div>
        <div class="nav-item">
          <div class="nav-item-icon m-icon-sales"></div>
          <div class="nav-item-text">Khuyến mãi</div>
        </div>
        <div class="nav-item m-manager-item">
          <div class="nav-item-icon m-icon-manager"></div>
          <div class="nav-item-text">
            <router-link to="/Stores">Danh mục</router-link>
          </div>
        </div>
        <div class="nav-item">
          <div class="nav-item-icon m-icon-setting"></div>
          <div class="nav-item-text">Cài đặt</div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
// import $ from "jquery";
export default {
  name: "TheNavbar",
  methods:{

  }
};
</script>

<style>
.m-manager-item{
  background-color: #1e235a;
}
</style>