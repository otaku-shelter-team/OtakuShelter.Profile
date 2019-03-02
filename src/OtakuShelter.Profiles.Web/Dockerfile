FROM microsoft/dotnet:2.2-sdk AS build
COPY . /otakushelter/profiles/service
WORKDIR /otakushelter/profiles/service/src/OtakuShelter.Profiles.Web
RUN dotnet publish -c Release -o artifacts

FROM microsoft/dotnet:2.2-aspnetcore-runtime AS runtime
WORKDIR /otakushelter/profiles/service
COPY --from=build /otakushelter/profiles/service/src/OtakuShelter.Profiles.Web/artifacts ./
ENTRYPOINT ["dotnet", "OtakuShelter.Profile.Web.dll"] 