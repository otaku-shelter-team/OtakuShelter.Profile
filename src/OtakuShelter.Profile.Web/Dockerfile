FROM microsoft/dotnet:2.2-sdk AS build
COPY . /otakushelter/profile/service
WORKDIR /otakushelter/profile/service/src/OtakuShelter.Profile.Web
RUN dotnet publish -c Release -o artifacts

FROM microsoft/dotnet:2.2-aspnetcore-runtime AS runtime
WORKDIR /otakushelter/profile/service
COPY --from=build /otakushelter/profile/service/src/OtakuShelter.Profile.Web/artifacts ./
ENTRYPOINT ["dotnet", "OtakuShelter.Profile.Web.dll"] 