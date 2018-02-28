--(,NULL,N'',N'',NULL),
--delete from [dbo].[Comments]
--delete from [dbo].[CloudProducts]
insert into [dbo].[CloudProducts] values
(1,NULL,N'云服务器 ECS（Elastic Compute Service）是一种弹性可伸缩的计算服务，助您降低 IT 成本，提升运维效率，使您更专注于核心业务创新',N'云服务器 ECS',NULL),
(1,NULL,N'海量、安全、低成本、高可靠的云存储服务，提供99.999999999%的数据可靠性。使用RESTful API 可以在互联网任何位置存储和访问，容量和处理能力弹性扩展，多种存储类型供选择全面优化存储成本。',N'对象存储 OSS',NULL),
(1,NULL,N'GPU云服务器是基于GPU应用的计算服务，多适用于AI深度学习,视频处理，科学计算，图形可视化，等应用场景，型号有AMD S7150， Nvidia M40， Nvidia P100，Nvidia P4，Nvidia V100',N'GPU云服务器',NULL),
(1,NULL,N'帮助您基于阿里云构建出一个隔离的网络环境，并可以自定义IP 地址范围、网段、路由表和网关等；此外，也可以通过专线/VPN/GRE等连接方式实现云上VPC与传统IDC的互联，构建混合云业务。',N'专有网络 VPC',NULL),
(1,NULL,N'文件存储 NAS（ Network Attached Storage ）是一种分布式的网络文件存储，为ECS、HPC、Docker、BatchCompute 等提供安全、无限容量、高性能、高可靠、简单易用的文件存储服务。',N'文件存储 NAS',NULL),
(1,NULL,N'SQL Server是发行最早的商用数据库产品之一，支持复杂的SQL查询，性能优秀，对基于Windows平台.NET架构的应用程序具有完美的支持。 ',N'云数据库 SQL Server 版',NULL),
(1,NULL,N'云盾DDoS高防IP是针对互联网服务器（包括非阿里云主机）在遭受大流量的DDoS攻击后导致服务不可用的情况下，推出的付费增值服务，用户可以通过配置高防IP，将攻击流量引流到高防IP，确保源站的稳定可靠。',N'DDoS高防IP',NULL),
(1,NULL,N'DataV旨让更多的人看到数据可视化的魅力，帮助非专业的工程师通过图形化的界面轻松搭建专业水准的可视化应用，满足您会议展览、业务监控、风险预警、地理信息分析等多种业务的展示需求。',N'DataV数据可视化',NULL),
(1,NULL,N'阿里云机器学习是基于阿里云分布式计算引擎的一款机器学习算法平台，以极低的代价帮助您的业务从BI时代跨入AI时代，真正实现人工智能触手可及。',N'数加 · 机器学习PAI',NULL)


insert into [dbo].[CloudProducts] values
(2,NULL,N'稳定、安全、弹性、高性能的云端计算服务，实时满足您的多样性业务需求',N'云服务器 CVM',NULL),
(2,NULL,N'安全稳定、海量、便捷、低延迟、低成本的云端存储服务',N'对象存储 COS',NULL),
(2,NULL,N'云数据库（Cloud DataBase CDB）是腾讯云提供的关系型数据库云服务，基于PCI-e SSD存储介质，提供高达245509 QPS的强悍性能。CDB 支持MySQL、SQL Server、TDSQL(兼容mariaDB)引擎，PostgreSQL等，相对于传统数据库更容易部署、管理和扩展，默认支持主从实时热备，并提供容灾、备份、恢复、监控、迁移等数据库运维全套解决方案。',N'云数据库CDB',NULL),
(2,NULL,N'安全稳定、低成本投入并且可弹性扩展的实用型流量分配服务',N'负载均衡 CLB',NULL),
(2,NULL,N'移动解析（HttpDNS）基于Http协议向腾讯云的DNS服务器发送域名解析请求，替代了基于DNS协议向运营商Local DNS发起解析请求的传统方式，可以避免Local DNS造成的域名劫持和跨网访问问题，解决移动互联网服务中域名解析异常带来的困扰。',N'移动解析HttpDNS',NULL),
(2,NULL,N'API 网关（API Gateway）是 API 托管服务。提供 API 的完整生命周期管理，包括创建、维护、发布、运行、下线等。您可使用 API Gateway 封装自身业务，将您的数据、业务逻辑或功能安全可靠的开放出来，用以实现自身系统集成、以及与合作伙伴的业务连接。',N'API网关',NULL),
(2,NULL,N'DI-Perceiver 实时多维分析引擎结合数据列存储技术和极速查询优化技术，向用户提供高性能的实时多维分析能力。您可以在无需预构建数据立方的情况下通过 SQL 语句对千亿级数据进行毫秒级的无限制上卷、下钻、切片、切块、旋转等分析操作，以快速洞察海量数据价值。',N'DI-P实时多维分析引擎',NULL)