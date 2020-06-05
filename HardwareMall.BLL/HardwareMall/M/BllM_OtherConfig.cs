//------------------
//-- Create By lookchem 3.0
//-- File: Bll/BllM_OtherConfig.cs
//-- 2020/3/12 13:44:19
//------------------
using System;
using System.Collections.Generic;
using System.Text;
using Dal;
using System.Data;
using Model.HardwareMall;
using HardwareMall.Tool.EnumHelper;
using HardwareMall.Tool.DataTableHelp;
using HardwareMall.Model;
using System.Data.SqlClient;
using System.Linq;

namespace Bll.HardwareMall
{
    public class BllM_OtherConfig:Bll.Base.HardwareMall.BllM_OtherConfig
    {
        private readonly BllM_Img _img = Bll.Base.HardwareMall.BllM_Img.Instance();
        /// <summary>
        /// 获取品牌页面内容(包括图片)
        /// </summary>
        /// <returns></returns>
        public OtherDto GetBrand()
        {
            string sql = @"select t.*,t1.ImgSrc from M_OtherConfig t 
                        left join M_Img t1 on t.TitleImg=t1.Id  where t.Type=" + (int)WebConfigEnum.Brand;
            var result = dal.ExecuteDataset(sql).Tables[0].ToList<OtherDto>()[0];
            return result;
        }

        /// <summary>
        /// 获取品牌页滚动图片
        /// </summary>
        /// <param name="ImgIDs"></param>
        /// <returns></returns>
        public List<ModM_Img> GetImg(string ImgIDs)
        {
            string sql = "select * from M_Img where Id in (" + ImgIDs + ")";
            var result = dal.ExecuteDataset(sql).Tables[0].ToList<ModM_Img>();
            return result;
        }

        /// <summary>
        /// 获取其他页面内容
        /// </summary>
        /// <returns></returns>
        public List<OtherDto> GetOtherConfig(int Type)
        {
            string sql = @"select t.*,t1.ImgSrc from M_OtherConfig t 
                        left join M_Img t1 on t.TitleImg = t1.Id  where t.Type = " + Type;
            var result = dal.ExecuteDataset(sql).Tables[0].ToList<OtherDto>();
            result.ForEach(m => {
                m.Contents = m.Content.Split('|');
            });
            return result;
        }

        /// <summary>
        /// 获取其他页面配置列表
        /// </summary>
        /// <returns></returns>
        public List<OtherDto> GetOtherConfigList(int Type)
        {
            string sql = @"select t.*,t1.ImgSrc from M_OtherConfig t 
                        left join M_Img t1 on t.TitleImg = t1.Id";
            if(Type!=0)
            {
                sql += " where Type=" + Type;
            }
            return dal.ExecuteDataset(sql).Tables[0].ToList<OtherDto>();
        }

        /// <summary>
        /// 获取编辑页
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public object GetOtherConfigInfo(int Id)
        {
            string sql = @"select t.*,t1.ImgSrc from M_OtherConfig t 
                        left join M_Img t1 on t.TitleImg = t1.Id where t.Id="+Id;
            var data= dal.ExecuteDataset(sql).Tables[0].Rows[0].RowToObj<OtherDto>();
            return new
            {
                title=data.Title,
                imgSrc=data.ImgSrc,
                content=data.Content,
                imgIds=data.ImgIDs,
                imgIds2=data.ImgIDs2
            };
        }

        /// <summary>
        /// 修改信息
        /// </summary>
        /// <param name="model"></param>
        public void UpdateOtherConfigInfo(ModM_OtherConfig model)
        {
            string sql = "update M_OtherConfig set TitleImg=@TitleImg,Title=@Title,Content=@Content where Id=@Id";
            SqlParameter[] parameters = {
                new SqlParameter("@TitleImg",model.TitleImg),
                new SqlParameter("@Title",model.Title),
                new SqlParameter("@Content",model.Content),
                new SqlParameter("@Id",model.Id),
            };
            dal.ExecuteNonQuery(sql, parameters);
        }

        /// <summary>
        /// 增加品牌页滚动图片
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="ImgSrc"></param>
        /// <param name="Type"></param>
        public void AddBrandImg(int Id, string ImgSrc, string Type)
        {
            var Info = dal.GetModel(Id);
            var ImgStr = string.Empty;
            string RowName = string.Empty;
            if (Type == "1")
            {
                ImgStr = Info.ImgIDs;
                RowName = "ImgIDs";
            }
            else if (Type == "2")
            {
                ImgStr = Info.ImgIDs2;
                RowName = "ImgIDs2";
            }
            List<string> ImgIds = ImgStr.Split(',').ToList();
            var ImgId=_img.Add(new ModM_Img 
            {
                ImgSrc= ImgSrc,
                CreateTime=DateTime.Now
            });
            ImgIds.Add(ImgId.ToString());
            string NewImgIds = string.Join(",", ImgIds);
            string sql = "update M_OtherConfig set " + RowName + "='" + NewImgIds + "' where Id=" + Id;
            dal.ExecuteNonQuery(sql);
        }

        /// <summary>
        /// 删除品牌页滚动图片
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="ImgSrc"></param>
        /// <param name="Type"></param>
        public void DelBrandImg(int Id, string ImgId, string Type)
        {
            var Info = dal.GetModel(Id);
            var ImgStr = string.Empty;
            string RowName = string.Empty;
            if (Type == "1")
            {
                ImgStr = Info.ImgIDs;
                RowName = "ImgIDs";
            }
            else if (Type == "2")
            {
                ImgStr = Info.ImgIDs2;
                RowName = "ImgIDs2";
            }
            List<string> ImgIds = ImgStr.Split(',').ToList();
            ImgIds.Remove(ImgId);
            string NewImgIds = string.Join(",", ImgIds);
            string sql = "update M_OtherConfig set " + RowName + "='" + NewImgIds + "' where Id=" + Id;
            dal.ExecuteNonQuery(sql);
        }
    }
}
