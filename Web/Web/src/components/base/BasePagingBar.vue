<template>
  <div>
    <div class="paging-bar">
      <div class="paging-center">
        <div class="paging-center-button" @click="handleFirstPage" title="Về trang đầu">
          <div class="m-paging-button pagi-icon-firstpage"></div>
        </div>
        <div class="paging-center-button" @click="handlePrevPage" title="Về trang trước">
          <div class="m-paging-button pagi-icon-prevpage"></div>
        </div>
        <div>Trang</div>
        <input type="text" class="paging-bar-input"  v-model="Page" title="Nhập số trang" />
        <div class="paging-center-text">trên {{ pagi }}</div>
        <div class="paging-center-button" @click="handleNextPage" title="Đến trang tiếp theo">
          <div class="m-paging-button pagi-icon-nextpage" ></div>
        </div>
        <div class="paging-center-button" @click="handleLastPage" title="Đến trang cuối">
          <div class="m-paging-button pagi-icon-lastpage"></div>
        </div>
        <div class="paging-center-button" title="Load lại trang" @click="btnRefresh">
          <div
            class="m-paging-button pagi-icon-loadpage"
            style="width: 12px; height: 12px"
          ></div>
        </div>
        <div>
          <select class="pagi-select">
            <option value="0">20</option>
            <option value="0">30</option>
          </select>
        </div>
      </div>
      <div class="paging-right"><label>Hiển thị {{ Stores.length }} trên {{ quantityStore }} kết quả</label></div>
    </div>
  </div>
</template>

<script>
import axios from "axios";
export default {
  name: "BasePaginingBar",
  data() {
    return {
      //Gán giá trị đầu là trang 1
      Page: 1,
    };
  },
  props: ["quantityStore", "Stores", "pagi"],
  methods: {
    //Xử lí khi ấn nút trở về trang đầu tiên
    // CreatedBy: hhminh(14/4/2021)
    handleFirstPage: function () {
      this.Page = 1;
      this.$emit("loadData", this.Page);
    },
    //Xử lí khi trở về trang phía trước
    // CreatedBy: hhminh(14/4/2021)
    handlePrevPage: function () {
      if (this.Page > 1) {
        this.Page--;
        this.$emit("loadData", this.Page);
      }
    },
    //Xử lí khi sang trang tiếp theo
    // CreatedBy: hhminh(14/4/2021)
    handleNextPage: function () {
      if (this.Page < this.pagi) {
        this.Page++;
        this.$emit("loadData", this.Page);
      }
    },
    //Hàm load dữ liệu
    // CreatedBy: hhminh(13/4/2021)
    btnRefresh() {
      this.loadData();
    },
    async loadData() {
      await axios.get("http://localhost:52139/api/v1/stores").then((res) => {
        this.stores = res.data;
        this.showLoading = false;
      });
    },
    //Xử lí khi về cuối trang
    // CreatedBy: hhminh(14/4/2021)
    handleLastPage: function () {
      this.Page = this.pagi;
      this.$emit("loadData", this.Page);
    },
  },
  watch: {
    //Xử lí khi nhập trang thông qua input
    // CreatedBy: hhminh(14/4/2021)
    Page: function () {
      if (this.Page == "") this.$emit("loadData", 1);
      else if (this.Page > 20) this.$emit("loadData", 20);
      else this.$emit("loadData", this.Page);
    },
  },
  created() {
    this.loadData();
  },
};

</script>
<style>
</style>