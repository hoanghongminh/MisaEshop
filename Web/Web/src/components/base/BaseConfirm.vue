<template>
  <div>
    <!--dialog-->
    <div
      class="m-dialog-close"
      :class="{ isHideConfirmDelete: isHideConfirmDelete }"
    >
      <div class="dialog-modal"></div>
      <div class="warn">
        <div class="form-header">
          <strong class="title item-center">Xóa dữ liệu</strong>
          <div class="btn-x item-center"  @click="btnClose">
            <i class="icon-x"></i>
          </div>
        </div>
        <div class="warn-body">
          <i class="icon-warn"></i>
          <div id="title-warn">
            Bạn có chắc chắn muốn xóa <strong>{{ store.storeCode }}</strong> khỏi danh sách cửa hàng
            ?
          </div>
        </div>
        <div class="btn-footer">
          <div class="btn-warn">
            <div>
              <button class="btn-delete"  @click="btnDelete">
                <i class="icon-delete"></i>
                <p>Xóa</p>
              </button>
            </div>
            <div
              class="m-close-delete btn-cancel item-center"
              @click="btnClose"
            >
              <i class="icon-x"></i>
              <p class="text-cancel">Hủy bỏ</p>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "BaseConfirm",
  props: ["isHideConfirmDelete", "store"],
  methods: {
    // Sự kiện button đóng DialogConfirm
    // CreatedBy: hhminh(11/4/2021)
    btnClose() {
      this.$emit("btnDelete", true);
    },
    // Sự kiện button Delete
    // CreatedBy: hhminh(11/4/2021)
    btnDelete() {
      this.$emit("deleteStore", this.store);
      this.btnClose();
      this.$emit("changStore", true);
    },
  },
};
</script>

<style>
@import "../../styles/basics/dialog-delete.css";
#title-warn{
   margin-left: 10px;
}
</style>